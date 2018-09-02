using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7_Translator
{
    public class HL7FileProcessor
    {
        public List<string> AntigensList = new List<string> { "IGG", "IGA", "IGM" };

        public const string ArrayName = "GAM";
        public const int controlCount = 3;

        public Dictionary<string, string> AntigenValueList = new Dictionary<string, string>();


        public void ProcessContent(string content, string date, string batchNumber)
        {
            // This is the string applications uses to split the text to sections
            string carveString = "P|"; // default value if config was empty
            if (ConfigurationManager.AppSettings.AllKeys.Contains("CarveString"))
                carveString = ConfigurationManager.AppSettings["CarveString"];

            var splittedContent = content.Split(carveString.ToCharArray());

            for (int i = 0; i < splittedContent.Length; i++)
            {
                var splittedRow = content.Split(new string[] { "\n\r" }, StringSplitOptions.None);
                foreach (string antigen in AntigensList)
                {
                    var value = GetRowValue(splittedRow, antigen);
                    AntigenValueList.Add(antigen, value);
                }
            }

            CreateFile(date, batchNumber);
        }

        private string GetRowValue(string[] HL7Row, string antigen)
        {
            var antigenRow = HL7Row.FirstOrDefault(a => a.ToLower().Contains(antigen.ToLower()));
            if (!string.IsNullOrEmpty(antigenRow))
            {
                var antigenDetails = antigenRow.Split(new char[] { '|' });
                if (antigenDetails.Length >= 4)
                {
                    return antigenDetails[3];
                }
            }

            throw new Exception($"The selected HL7 file does not contain rows for antigen={antigen}");
        }

        private void CreateFile(string date, string batchNumber)
        {
            // get antigen names for the ones we have values for
            var antigens = AntigenValueList.Select(a => a.Key).Distinct();

            foreach (var antigen in antigens)
            {
                var fileName = $"{ArrayName}{antigen}.{date}.{batchNumber}";
                var fileContent = new StringBuilder($"Experiment File Name:,{fileName}.xpt\n\r\n\r");

                // Adding control values
                for (int i = 0; i < controlCount; i++)
                {
                    fileContent.Append($"CTL{i},{AntigenValueList[antigen][i]}\n\r");
                }

                fileContent.Append("\n\rBLK,?????\n\r");

                // Adding specimen values
                for (int i = controlCount; i < AntigenValueList[antigen].Length; i++)
                {
                    fileContent.Append($"SPL{i},{AntigenValueList[antigen][i]}\n\r");
                }

                string destinationPath = string.Empty;
                if (ConfigurationManager.AppSettings.AllKeys.Contains("DefaultPath"))
                    destinationPath = ConfigurationManager.AppSettings["DefaultPath"];

                using (var tw = new StreamWriter($"{ destinationPath }/{ fileName }.txt"))
                {
                    tw.Write(fileContent.ToString());
                }
            }
        }
    }
}

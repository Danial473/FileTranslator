using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HL7_Translator.Properties;

namespace HL7_Translator
{
    public class HL7FileProcessor
    {
        public List<string> AntigensList = new List<string> { "IGG", "IGA", "IGM" };
        public List<AntigenValue> AntigenValueList = new List<AntigenValue>();
        public string FilePath { get; set; }

        public const string ArrayName = "GAM";


        public void ProcessContent(string content, string date, string batchNumber)
        {
            // This is the string applications uses to split the text to sections
            string carveString = "P|"; // default value if config was empty
            if (!string.IsNullOrWhiteSpace(Settings.Default["FileSplitterString"].ToString()))
                carveString = Convert.ToString(Settings.Default["FileSplitterString"]);

            var header = content.Substring(content.IndexOf("PuTTY"), 29);

            var splittedContent = content.Split(new[] { carveString }, StringSplitOptions.None);

            for (int i = 1; i < splittedContent.Length; i++)
            {
                var splittedRow = splittedContent[i].Split(new string[] { "\r\n" }, StringSplitOptions.None);
                foreach (string antigen in AntigensList)
                {
                    // Get Accession Number
                    var accessionDetails = splittedRow[2].Split(new[] { '|' })[2].Split(new[] { '^' });

                    //get result value
                    var value = GetRowValue(splittedRow, antigen);
                    AntigenValueList.Add(new AntigenValue
                    {
                        AntigenName = antigen,
                        Value = value,
                        AccessionNumber = accessionDetails[0], // per requirements changes on July 18, 2019
                        RackNumber = accessionDetails[1],
                        RackPosition = accessionDetails[2]
                    });
                }
            }

            CreateFile(date, batchNumber, header);
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

        private void CreateFile(string date, string batchNumber, string header)
        {
            string destinationPath = GetDestinationPath();

            // check file exists and if overwrite needed 
            if (AntigensList.Any(a => File.Exists($"{ destinationPath }\\{ArrayName}{a}.{date}.{batchNumber}.txt")))
            {
                if (!Overwrite())
                {
                    return;
                }
            }

            // get antigen names for the ones we have values for and write file content into text files
            foreach (var antigen in AntigensList)
            {
                var antigenValues =
                    AntigenValueList.Where(a => a.AntigenName == antigen)
                    .OrderBy(a => a.RackNumber)
                    .ThenBy(a => a.RackPosition).ToList();

                if (antigenValues.Any())
                {
                    var fileName = $"{ArrayName}{antigen}.{date}.{batchNumber}";
                    //var fileContent = new StringBuilder($"Experiment File Name:,{fileName}.xpt\r\n\r\n");
                    var fileContent = new StringBuilder($"{header} {antigen}\r\n");
                    
                    foreach (var antigenValue in antigenValues)
                    {
                        fileContent.AppendLine($"RCK{antigenValue.RackNumber},{antigenValue.RackPosition},{antigenValue.Value},{antigenValue.AccessionNumber}");
                    }

                    string path = $"{ destinationPath }\\{ fileName }.txt";

                    using (var tw = new StreamWriter(path))
                    {
                        tw.Write(fileContent.ToString());
                    }
                }
            }

            System.Windows.MessageBox.Show("Translation process completed", "", MessageBoxButton.OK);
        }

        /// <summary>
        /// Shows confirmation dialog to overwite or not
        /// </summary>
        /// <returns></returns>
        private bool Overwrite()
        {
            string sMessageBoxText = "Translated files already exist. Would you like to overwrite them?";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, string.Empty, btnMessageBox, icnMessageBox);

            return rsltMessageBox == MessageBoxResult.Yes;
        }

        /// <summary>
        /// Returns destination path
        /// </summary> 
        private string GetDestinationPath()
        {
            string destinationPath = string.Empty;
            if (!string.IsNullOrEmpty(Settings.Default["FileDestinationDefaultPath"].ToString()))
                destinationPath = Settings.Default["FileDestinationDefaultPath"].ToString();
            else
            {
                var dialog = new System.Windows.Forms.FolderBrowserDialog();
                if (Convert.ToBoolean(dialog.ShowDialog()))
                {
                    destinationPath = dialog.SelectedPath;
                }
            }

            return destinationPath;
        }
    }
}

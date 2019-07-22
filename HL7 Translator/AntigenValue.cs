using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7_Translator
{
    public class AntigenValue
    {
        public string AntigenName { get; set; }
        public string Value { get; set; }
        public string AccessionNumber { get; set; }
        public string RackNumber { get; set; }
        public string RackPosition { get; set; }
    }
}

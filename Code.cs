using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SchemesGenerator
{
    class CodeUnit
    {
        private string FileName { get; set; }
        public string[] Code { get; private set; }
        public CodeUnit(string FileName)
        {
            Code = System.IO.File.ReadAllLines(FileName);
        }
        
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemesGenerator
{
    public class Subprogram
    {
        public string Name { get; set; }
        public string ResultType { get; set; }
        public string[] Params { get; set; }
        public List<Operator> Operators { get; set; } 
    }
}

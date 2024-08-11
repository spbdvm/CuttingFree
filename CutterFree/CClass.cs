using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutterX
{
    public class CClass
    {
        public int maxLength { get; set; }
        public int waste { get; set; }

        public int[] lengths  { get; set; }
        public int[] amounts { get; set; }

        public string[] marks { get; set; }
    }

    public class CuttingResult {
        public int N { get; set; }
        public string Artikl { get; set; }
        public int ProfileLenght { get; set; }
        public int Count { get; set; }
        public string MapOfCutting { get; set; }
        public decimal Remainder { get; set; }

    }
}

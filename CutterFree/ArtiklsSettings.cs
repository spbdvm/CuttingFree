using CuttingStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutterX
{
    public class ArtiklsSettings
    {
        public String Art { get; set; }
        public int?  Length { get; set; }

        public int? ProfileLength { get; set; }
        public int?  nReik { get; set; }

    }

    public class  resCut {
        public CuttingPlan cutt;
        public ArtiklsSettings artSettl;
        public resCut(CuttingPlan _cutt , ArtiklsSettings _artSettl) {
            cutt = _cutt;
            artSettl = _artSettl;
        }
    }
}

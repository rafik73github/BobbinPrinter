using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobbinPrinter
{
    class Yarns
    {
               
        public string YarnMaker { get; set; }
        public string YarnType { get; set; }
        public string YarnSize { get; set; }
        public string YarnColor { get; set; }

        public Yarns()
        {

        }

        public Yarns (string yarnMaker, string yarnType, string yarnSize, string yarnColor)
        {
            YarnMaker = yarnMaker;
            YarnType = yarnType;
            YarnSize = yarnSize;
            YarnColor = yarnColor;
        }

    }
}

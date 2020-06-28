using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobbinPrinter
{
    class Yarns
    {
        // TODO: add string YarnType (type of yarn e.g. cotton, acrillic... 
        // add string YarnSize(e.g. 32/2 ...
        
        public string YarnMaker { get; set; }
        public string YarnColor { get; set; }

        public Yarns()
        {

        }

        public Yarns (string yarnMaker, string yarnColor)
        {
            YarnMaker = yarnMaker;
            YarnColor = yarnColor;
        }

    }
}

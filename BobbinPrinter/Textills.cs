using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobbinPrinter
{
    class Textills
    {

        public string TextillMaker { get; set; }
        public string TextillStuff { get; set; }
        public string TextillColor { get; set; }

        public Textills()
        {

        }

        public Textills (string textillMaker, string textillStuff, string textillColor)
        {
            TextillMaker = textillMaker;
            TextillStuff = textillStuff;
            TextillColor = textillColor;
        }

    }
}

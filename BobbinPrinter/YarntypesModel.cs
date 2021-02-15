using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobbinPrinter
{
    class YarntypesModel
    {

        public int YarntypeId { get; set; }
        public string YarntypeName { get; set; }
        public bool YarntypeArchived { get; set; }


        public YarntypesModel(int yarntypeId, string yarntypeName, bool yarntypeArchived)
        {
            this.YarntypeId = yarntypeId;
            this.YarntypeName = yarntypeName;
            this.YarntypeArchived = yarntypeArchived;
        }

        public YarntypesModel(string yarntypeName, bool yarntypeArchived)
        {
            this.YarntypeName = yarntypeName;
            this.YarntypeArchived = yarntypeArchived;
        }

    }
}

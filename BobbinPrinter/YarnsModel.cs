using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobbinPrinter
{
    class YarnsModel
    {

        public int YarnId { get; set; }
        public int YarnMaker { get; set; }
        public string YarnMakerString { get; set; }
        public int YarnType { get; set; }
        public string YarnTypeString { get; set; }
        public int YarnSize { get; set; }
        public string YarnSizeString { get; set; }
        public string YarnColor { get; set; }
        public bool YarnArchived { get; set; }

        public YarnsModel()
        {

        }

        public YarnsModel (int yarnId, int yarnMaker, string yarnMakerString, int yarnType, string yarnTypeString, int yarnSize, string yarnSizeString, string yarnColor, bool yarnArchived)
        {
            this.YarnId = yarnId;
            this.YarnMaker = yarnMaker;
            this.YarnMakerString = yarnMakerString;
            this.YarnType = yarnType;
            this.YarnTypeString = yarnTypeString;
            this.YarnSize = yarnSize;
            this.YarnSizeString = yarnSizeString;
            this.YarnColor = yarnColor;
            this.YarnArchived = yarnArchived;
        }

        public YarnsModel(int yarnId, int yarnMaker, int yarnType, int yarnSize, string yarnColor, bool yarnArchived)
        {
            this.YarnId = yarnId;
            this.YarnMaker = yarnMaker;
            this.YarnType = yarnType;
            this.YarnSize = yarnSize;
            this.YarnColor = yarnColor;
            this.YarnArchived = yarnArchived;
        }

        public YarnsModel(int yarnMaker, int yarnType, int yarnSize, string yarnColor, bool yarnArchived)
        {
            this.YarnMaker = yarnMaker;
            this.YarnType = yarnType;
            this.YarnSize = yarnSize;
            this.YarnColor = yarnColor;
            this.YarnArchived = yarnArchived;
        }

    }
}

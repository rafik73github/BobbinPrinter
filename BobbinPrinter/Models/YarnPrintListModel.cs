namespace BobbinPrinter.Models
{
    class YarnPrintListModel
    {

        public int PrintListId { get; set; }
        public string YarnColor { get; set; }
        public string YarnLot { get; set; }
        public int YarnBobbinInPackageCount { get; set; }
        public int YarnBobbinAmount { get; set; }
        public string YarnSize { get; set; }
        public string YarnMaker { get; set; }


        public YarnPrintListModel(int printListId, string yarnColor, string yarnLot, int yarnBobbinAmount, string yarnSize)
        {
            PrintListId = printListId;
            YarnColor = yarnColor;
            YarnLot = yarnLot;
            YarnBobbinAmount = yarnBobbinAmount;
            YarnSize = yarnSize;
        }

        public YarnPrintListModel(string yarnColor, string yarnLot, int yarnBobbinInPackageCount, int yarnBobbinAmount, string yarnSize, string yarnMaker)
        {
            YarnColor = yarnColor;
            YarnLot = yarnLot;
            YarnBobbinInPackageCount = yarnBobbinInPackageCount;
            YarnBobbinAmount = yarnBobbinAmount;
            YarnSize = yarnSize;
            YarnMaker = yarnMaker;
        }


    }
}

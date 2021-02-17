namespace BobbinPrinter.Models
{
    class YarnPrintListModel
    {

        public int PrintListId { get; set; }
        public string YarnColor { get; set; }
        public string YarnLot { get; set; }
        public int YarnBobbinAmount { get; set; }
        public string YarnSize { get; set; }


        public YarnPrintListModel(int printListId, string yarnColor, string yarnLot, int yarnBobbinAmount, string yarnSize)
        {
            this.PrintListId = printListId;
            this.YarnColor = yarnColor;
            this.YarnLot = yarnLot;
            this.YarnBobbinAmount = yarnBobbinAmount;
            this.YarnSize = yarnSize;
        }

        public YarnPrintListModel(string yarnColor, string yarnLot, int yarnBobbinAmount, string yarnSize)
        {
            this.YarnColor = yarnColor;
            this.YarnLot = yarnLot;
            this.YarnBobbinAmount = yarnBobbinAmount;
            this.YarnSize = yarnSize;
        }


    }
}

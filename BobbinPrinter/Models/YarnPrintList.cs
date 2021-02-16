namespace BobbinPrinter.Models
{
    class YarnPrintList
    {

        public int PrintListId { get; set; }
        public YarnsModel YarnModel { get; set; }
        public string YarnLot { get; set; }
        public int YarnBobbinAmount { get; set; }

        public YarnPrintList(int printListId, YarnsModel yarnsModel, string yarnLot, int yarnBobbinAmount)
        {
            this.PrintListId = printListId;
            this.YarnModel = yarnsModel;
            this.YarnLot = yarnLot;
            this.YarnBobbinAmount = yarnBobbinAmount;
        }


    }
}

namespace BobbinPrinter.Models
{
    class YarnmakersModel
    {
        public int YarnmakerId { get; set; }
        public string YarnmakerName { get; set; }
        public bool YarnmakerArchived { get; set; }
       

        public YarnmakersModel(string yarnmakerName, bool yarnmakerArchived)
        {
            this.YarnmakerName = yarnmakerName;
            this.YarnmakerArchived = yarnmakerArchived;
        }

        public YarnmakersModel(int yarnmakerId, string yarnmakerName, bool yarnmakerArchived)
        {
            this.YarnmakerId = yarnmakerId;
            this.YarnmakerName = yarnmakerName;
            this.YarnmakerArchived = yarnmakerArchived;
        }

    }

    
}

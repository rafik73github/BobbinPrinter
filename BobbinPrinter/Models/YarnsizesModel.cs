namespace BobbinPrinter.Models
{
    class YarnsizesModel
    {

        public int YarnsizeId { get; set; }
        public string YarnsizeName { get; set; }
        public bool YarnsizeArchived { get; set; }


        public YarnsizesModel(int yarnsizeId, string yarnsizeName, bool yarnsizeArchived)
        {
            this.YarnsizeId = yarnsizeId;
            this.YarnsizeName = yarnsizeName;
            this.YarnsizeArchived = yarnsizeArchived;
            
        }

        public YarnsizesModel(string yarnsizeName, bool yarnsizeArchived)
        {
            this.YarnsizeName = yarnsizeName;
            this.YarnsizeArchived = yarnsizeArchived;

        }
    }
}

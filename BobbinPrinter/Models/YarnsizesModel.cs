namespace BobbinPrinter.Models
{
    class YarnsizesModel
    {

        public int YarnsizeId { get; set; }
        public string YarnsizeName { get; set; }
        public bool YarnsizeArchived { get; set; }


        public YarnsizesModel(int yarnsizeId, string yarnsizeName, bool yarnsizeArchived)
        {
            YarnsizeId = yarnsizeId;
            YarnsizeName = yarnsizeName;
            YarnsizeArchived = yarnsizeArchived;
            
        }

        public YarnsizesModel(string yarnsizeName, bool yarnsizeArchived)
        {
            YarnsizeName = yarnsizeName;
            YarnsizeArchived = yarnsizeArchived;

        }
    }
}

namespace BobbinPrinter.Models
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

        public int YarnBobbinInPackageCount { get; set; }
        public bool YarnArchived { get; set; }

        public YarnsModel()
        {

        }

        public YarnsModel (int yarnId, int yarnMaker, string yarnMakerString, int yarnType, string yarnTypeString, int yarnSize, string yarnSizeString, string yarnColor, int yarnBobbinInPackageCount, bool yarnArchived)
        {
            YarnId = yarnId;
            YarnMaker = yarnMaker;
            YarnMakerString = yarnMakerString;
            YarnType = yarnType;
            YarnTypeString = yarnTypeString;
            YarnSize = yarnSize;
            YarnSizeString = yarnSizeString;
            YarnColor = yarnColor;
            YarnBobbinInPackageCount = yarnBobbinInPackageCount;
            YarnArchived = yarnArchived;
        }

        public YarnsModel(int yarnId, int yarnMaker, int yarnType, int yarnSize, string yarnColor, bool yarnArchived)
        {
            YarnId = yarnId;
            YarnMaker = yarnMaker;
            YarnType = yarnType;
            YarnSize = yarnSize;
            YarnColor = yarnColor;
            YarnArchived = yarnArchived;
        }

        public YarnsModel(int yarnMaker, int yarnType, int yarnSize, string yarnColor, int yarnBobbinInPackageCount, bool yarnArchived)
        {
            YarnMaker = yarnMaker;
            YarnType = yarnType;
            YarnSize = yarnSize;
            YarnColor = yarnColor;
            YarnBobbinInPackageCount = yarnBobbinInPackageCount;
            YarnArchived = yarnArchived;
        }

    }
}

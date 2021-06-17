namespace BobbinPrinter.Models
{
    class YarntypesModel
    {

        public int YarntypeId { get; set; }
        public string YarntypeName { get; set; }
        public bool YarntypeArchived { get; set; }


        public YarntypesModel(int yarntypeId, string yarntypeName, bool yarntypeArchived)
        {
            YarntypeId = yarntypeId;
            YarntypeName = yarntypeName;
            YarntypeArchived = yarntypeArchived;
        }

        public YarntypesModel(string yarntypeName, bool yarntypeArchived)
        {
            YarntypeName = yarntypeName;
            YarntypeArchived = yarntypeArchived;
        }

    }
}

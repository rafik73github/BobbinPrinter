using System.IO;

namespace BobbinPrinter.Tools
{
    class FileTools
    {

        public static bool IsFileLocked(FileInfo file)
        {
            if (file.Exists)
            {
                try
                {
                    using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        stream.Close();
                    }
                }
                catch (IOException)
                {
                    //the file is unavailable because it is:
                    //still being written to
                    //or being processed by another thread
                    //or does not exist (has already been processed)
                    return true;
                }
            }
            //file is not locked
            return false;
        }

    }
}

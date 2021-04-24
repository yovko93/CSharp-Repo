namespace LoggerExc.Models.Contracts
{
    public interface IPathManager
    {
        //bin/debug
        string CurrentDirectoryPath { get; }


        //bin/debug/logfile.txt
        string CurrentFilePath { get; }


        /// It tells me where my app is running now on user pc
        string GetCurrentPath();


        /// It will ensure that selected directory and file will exist
        void EnsureDirectoryAndFileExists();
    }
}

namespace ConsoleApp1
{
    public interface ILoggingService
    {
        void DeleteLine(int rowIndex);
        void Log(string tolog);
        void Log(SharedTypes.LogLineModel tolog);
    }
}
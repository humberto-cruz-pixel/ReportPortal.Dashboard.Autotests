namespace ReporterLibrary.Interfaces.Reporters
{
    public interface IReporterService
    {
        void CloseAndFlushReport();
        void CreateTest(string testName);
        dynamic GetReport();
        void LogFail(string message);
        void LogInfo(string message);
        void LogPass(string message);
        void LogScreenshot(string message, string image);
    }
}
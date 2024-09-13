using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using ReporterLibrary.Interfaces.Reporters;
using System;
using System.IO;
using System.Reflection;

namespace ReporterLibrary.Reporters
{
    public class ExtentReporterService : IReporterService
    {
        private readonly ExtentReports _extenReport;
        private ExtentTest _extentTest;

        public ExtentReporterService()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "results'\'");

            Directory.CreateDirectory(path);

            _extenReport = new ExtentReports();
            var _extentHtmlReporter = new ExtentSparkReporter(path);

            _extenReport.AttachReporter(_extentHtmlReporter);
        }

        public void CreateTest(string testName)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(testName);

            _extentTest = _extenReport.CreateTest(testName);
        }

        public void LogInfo(string message) => _extentTest.Info(message);
        public void LogPass(string message) => _extentTest.Pass(message);
        public void LogFail(string message) => _extentTest.Fail(message);
        public void LogScreenshot(string message, string image)
        {
            _extentTest.Info(message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }
        public void CloseAndFlushReport() => _extenReport.Flush();

        public dynamic GetReport()
        {
            return _extenReport;
        }
    }
}

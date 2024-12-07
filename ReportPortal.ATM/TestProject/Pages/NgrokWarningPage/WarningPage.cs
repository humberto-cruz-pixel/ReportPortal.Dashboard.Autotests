using LoggerLibrary.Interfaces.Loggers;
using OpenQA.Selenium;
using System;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Pages.NgrokWarningPage;

public partial class WarningPage
{
    private readonly IWebDriverService _webDriverService;
    private readonly IWebDriver _webDriver;
    private readonly ILoggerService _loggerService;

    public WarningPage(IWebDriverService webDriverService, ILoggerService loggerService)
    {
        ArgumentNullException.ThrowIfNull(webDriverService);
        ArgumentNullException.ThrowIfNull(loggerService);

        _webDriverService = webDriverService;
        _webDriver = _webDriverService.GetWebDriver();
        _loggerService = loggerService;

        _loggerService.LogInformation("Ngrok Warning page complete");
    }

    public void OpenVisitSite()
    {
        ClickOnVisistsite();
    }
}

using LoggerLibrary.Interfaces.Loggers;
using OpenQA.Selenium;
using System;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Pages.NavBar;

public partial class NavBarPage
{
    private readonly IWebDriverService _webDriverService;
    private readonly IWebDriver _webDriver;
    private readonly ILoggerService _loggerService;

    public NavBarPage(IWebDriverService webDriverService, ILoggerService loggerService)
    {
        ArgumentNullException.ThrowIfNull(webDriverService);
        ArgumentNullException.ThrowIfNull(loggerService);

        _webDriverService = webDriverService;
        _webDriver = _webDriverService.GetWebDriver();
        _loggerService = loggerService;

        _loggerService.LogInformation("Navigation bar Page instantiation complete");
    }

    public void OpenDashboardsPage()
    {
        ClickOnDashboardsPage();
    }
}

using LoggerLibrary.Interfaces.Loggers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Pages.AllDashboardPage;

public partial class AllDashboardsPage
{
    private readonly IWebDriverService _webDriverService;
    private readonly IWebDriver _webDriver;
    private readonly ILoggerService _loggerService;

    public AllDashboardsPage(IWebDriverService webDriverService, ILoggerService loggerService)
    {
        ArgumentNullException.ThrowIfNull(webDriverService);
        ArgumentNullException.ThrowIfNull(loggerService);

        _webDriverService = webDriverService;
        _webDriver = _webDriverService.GetWebDriver();
        _loggerService = loggerService;

        _loggerService.LogInformation("All Dashboards Page instantiation complete");
    }

    public void OpenCreateNewDashboard()
    {
        ClickOnAddNewDashboard();
    }

    public void OpenDashboard(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        ClickOnDashboard(name);
    }

    public void OpenEditDashboard()
    {
        ClickOnEditDashboard();
    }

    public IList<string> GetDashboardNames()
    {
        WaitForDashboards();
        return DashboardNames.Select(x => x.Text).ToList();
    }

    public IList<string> GetDashboardsDescriptions()
    {
        WaitForDashboardDescriptions();
        return DashboardDescriptions.Select(x => x.Text).ToList();
    }
}
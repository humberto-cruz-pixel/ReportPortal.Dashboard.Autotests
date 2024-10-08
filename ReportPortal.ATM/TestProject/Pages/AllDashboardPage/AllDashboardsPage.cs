using OpenQA.Selenium;
using System;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Pages.AllDashboardPage;

public partial class AllDashboardsPage
{
    private readonly IWebDriverService _webDriverService;
    private readonly IWebDriver _webDriver;

    public AllDashboardsPage(IWebDriverService webDriverService)
    {
        ArgumentNullException.ThrowIfNull(webDriverService);

        _webDriverService = webDriverService;
        _webDriver = _webDriverService.GetWebDriver();
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

    public bool CheckDashboardExists(string name, string description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);

        if(DashboardElementExists(name) && DashboardElementExists(description))
            return true;
        return false;
    }       
}

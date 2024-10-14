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

    public void CheckDashboardName(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        Assert.That(FindDashboardName(name).Displayed, Is.EqualTo(true));
    }

    public void CheckDashboardDescription(string description)
    {
        ArgumentException.ThrowIfNullOrEmpty(description);

        Assert.That(FindDashboardDescription(description).Displayed, Is.EqualTo(true));
    }
}

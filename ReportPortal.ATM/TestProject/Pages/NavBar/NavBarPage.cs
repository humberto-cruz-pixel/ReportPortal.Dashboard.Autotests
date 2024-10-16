using OpenQA.Selenium;
using System;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Pages.NavBar;

public partial class NavBarPage
{
    private readonly IWebDriverService _webDriverService;
    private readonly IWebDriver _webDriver;

    public NavBarPage(IWebDriverService webDriverService)
    {
        ArgumentNullException.ThrowIfNull(webDriverService);

        _webDriverService = webDriverService;
        _webDriver = _webDriverService.GetWebDriver();
    }

    public void OpenDashboardsPage()
    {
        ClickOnDashboardsPage();
    }
}

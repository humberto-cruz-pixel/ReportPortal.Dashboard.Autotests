using System;
using WebDriverLibrary.Extensions.WebDrivers;

namespace TestProject.Pages.NavBar;

public partial class NavBarPage
{
    private void ClickOnDashboardsPage()
    {
        try
        {
            _webDriver.WaitUntilElementIsClickable(_dashboardsPageLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            DashboardsPageButton.Click();
        }
        catch (Exception e) { throw; }
    }
}

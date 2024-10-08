using System;
using WebDriverLibrary.Extensions.WebDrivers;

namespace TestProject.Pages.AllDashboardPage;

public partial class AllDashboardsPage
{
    private void ClickOnAddNewDashboard()
    {
        try
        {
            _webDriver.WaitUntilElementIsClickable(_addNewDashboardLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            AddNewDashboardButton.Click();
        }
        catch (Exception e) { throw;}
    }

    private void ClickOnEditDashboard()
    {
        try
        {
            _webDriver.WaitUntilElementIsClickable(_editDashboardLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            EditDashboardButton.Click();
        }
        catch (Exception e) { throw; }
    }

    private void ClickOnDashboard(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        try
        {
            DashboardInfoElement(name).Click();
        }
        catch (Exception e) { throw; }
    }

    private bool DashboardElementExists(string info)
    {
        ArgumentException.ThrowIfNullOrEmpty(info);

        try
        {
            return DashboardInfoElement(info).Displayed;
        }
        catch (Exception e) { throw; }
    }
}

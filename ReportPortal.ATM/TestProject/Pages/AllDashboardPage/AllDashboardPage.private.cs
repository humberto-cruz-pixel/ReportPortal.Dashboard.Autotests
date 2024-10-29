using OpenQA.Selenium;
using System;
using System.Linq;
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
        catch (Exception e) { throw; }
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
            WaitForDashboards();
            GetDashboardByName(name).Click();
        }
        catch (Exception e) { throw; }
    }

    private void WaitForDashboards()
    {
        try
        {
            _webDriver.WaitUntilElementIsVisible(_dashboardNamesLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);
        }
        catch (Exception e) { throw; }
    }

    private void WaitForDashboardDescriptions()
    {
        try
        {
            _webDriver.WaitUntilElementIsVisible(_dashboardDescriptionsLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);
        }
        catch (Exception e) { throw; }
    }

    private IWebElement GetDashboardByName(string name) =>
        DashboardNames.FirstOrDefault(x => x.Text.Equals(name, StringComparison.Ordinal));
}

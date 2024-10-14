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
            FindDashboardName(name).Click();
        }
        catch (Exception e) { throw; }
    }

    private IWebElement FindDashboardName(string name)
    {
        try
        {
            _webDriver.WaitUntilElementIsVisible(_dashboardNamesLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            return DashboardNames.FirstOrDefault(x => x.Text.Equals(name));
        }
        catch (Exception e) { throw; }
    }

    private IWebElement FindDashboardDescription(string description)
    {
        try
        {
            _webDriver.WaitUntilElementIsVisible(_dashboardDescriptionsLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            return DashboardDescriptions.FirstOrDefault(x => x.Text.Equals(description));
        }
        catch (Exception e) { throw; }
    }
}

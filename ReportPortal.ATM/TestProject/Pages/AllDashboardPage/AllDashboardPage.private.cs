using OpenQA.Selenium;
using System;
using System.Linq;
using WebDriverLibrary.Extensions.Helpers;
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

            _webDriver.ScrollToElement(AddNewDashboardButton);
            _webDriver.WaitForCondition(webDriver => webDriver.IsElementScrolledIntoView(AddNewDashboardButton),
                _webDriverService.GetWebDriverConfiguration().ShortTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            AddNewDashboardButton.Click();

        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "An error occurred while clicking on add new dashboard button", _addNewDashboardLocator);
            throw;
        }
    }

    private void ClickOnEditDashboard()
    {
        try
        {
            _webDriver.WaitUntilElementIsClickable(_editDashboardLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            _webDriver.ScrollToElement(EditDashboardButton);

            EditDashboardButton.Click();
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "An error occurred while clicking on edit dashboard button", _editDashboardLocator);
            throw;
        }
    }

    private void ClickOnDashboard(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        try
        {
            WaitForDashboards();
            GetDashboardByName(name).Click();
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, $"An error occurred while clicking on dashboard with name {name}", name);
            throw;
        }
    }

    private void WaitForDashboards()
    {
        try
        {
            _webDriver.WaitUntilElementIsVisible(_dashboardNamesLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "An error occurred while waiting for dashboards to be vsisble ", _dashboardNamesLocator);
            throw;
        }
    }

    private void WaitForDashboardDescriptions()
    {
        try
        {
            _webDriver.WaitUntilElementIsVisible(_dashboardDescriptionsLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "An error occurred while waiting for dashboards descriptions to be vsisble ", _dashboardDescriptionsLocator);
            throw;
        }
    }

    private IWebElement GetDashboardByName(string name) =>
        DashboardNames.FirstOrDefault(x => x.Text.Equals(name, StringComparison.Ordinal));
}

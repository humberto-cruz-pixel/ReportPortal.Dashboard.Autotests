using System;
using WebDriverLibrary.Extensions.WebDrivers;

namespace TestProject.Pages.DashboardPage;

public partial class DashboardPage
{
    private void ClickOnDeleteButton()
    {
        try
        {
            _webDriver.WaitUntilElementIsClickable(_deleteButtonLoocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            DeleteButton.Click();
        }
        catch (Exception e) { throw; }
    }

    private void ClickOnConfirmDeleteButton()
    {
        try
        {
            _webDriver.WaitUntilElementIsClickable(_confirmDeleteButtonLoocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            ConfirmDeleteButton.Click();
        }
        catch (Exception e) { throw; }
    }

    private void ClickOnAddWidgetButton()
    {
        try
        {
            _webDriver.WaitUntilElementIsClickable(_addWidgetButtonLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            AddWidgetButton.Click();
        }
        catch (Exception e) { throw; }
    }

    private void WaitForWidgetNames()
    {
        try
        {
            _webDriver.WaitUntilElementExists(_widgetNamesLocator,
            _webDriverService.GetWebDriverConfiguration().LongTimeout,
            _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);
        }
        catch (Exception e) { throw; }
    }

    private void WaitForWidgetTypes()
    {
        try
        {
            _webDriver.WaitUntilElementExists(_widgetTypesLocator,
            _webDriverService.GetWebDriverConfiguration().LongTimeout,
            _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);
        }
        catch (Exception e) { throw; }
    }
}
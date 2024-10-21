using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
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

    private IList<string> GetWidgetNames()
    {
        try
        {
            if (_widgetNames.Count == 0)
            {
                _webDriver.WaitUntilElementExists(_widgetNamesLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

                _widgetNames = WidgetNames.Select(x => x.Text).ToList();
            }
            return _widgetNames;
        }
        catch (Exception e) { throw; }
    }


    private IList<string> GetWidgetTypes()
    {
        try
        {
            if (_widgetTypes.Count == 0)
            {
                _webDriver.WaitUntilElementExists(_widgetTypesLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

                _widgetTypes = WidgetTypes.Select(x => x.Text).ToList();
            }
            return _widgetTypes;
        }
        catch (Exception e) { throw; }
    }
}

using OpenQA.Selenium;
using System;
using System.Linq;
using WebDriverLibrary.Extensions.WebDrivers;

namespace TestProject.Pages.AddNewWidgetPage;

public partial class AddNewWidgetPage
{
    private void ClickWidgetLabel(string label)
    {
        try
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(label);

            _webDriver.WaitUntilElementIsVisible(_widgetListLocator,
                        _webDriverService.GetWebDriverConfiguration().LongTimeout,
                        _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            WidgetList
                .First(widget => widget.Text.Equals(label, StringComparison.OrdinalIgnoreCase))
                .FindElement(_precedingSiblingContainerLabelLocator)
                .Click();
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "An error occurred while clicking on widget type button", _widgetListLocator);
            throw;
        }
    }

    private void ClickOneNextStepButton()
    {
        try
        {
            _webDriver.WaitUntilElementIsClickable(_nextStepButtonLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            NextStepButton.Click();
        }
        catch (Exception e) 
        {
            _loggerService.LogError(e, "An error occurred while clicking on next setp button", _nextStepButtonLocator);
            throw; 
        }
    }

    private void ClickOnDefaultFilter()
    {
        try
        {
            _webDriver.WaitUntilElementIsClickable(_defaultFilterSelector,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            DefaultFilter.Click();
        }
        catch (Exception e) 
        {
            _loggerService.LogError(e, "An error occurred while clicking on default filter button", _defaultFilterSelector);
            throw; 
        }
    }

    private void WidgetNameClearAndSendKeys(string name)
    {
        try
        {
            _webDriver.WaitUntilElementExists(_widgetNameInputLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            WidgetNameInput.Clear();
            WidgetNameInput.SendKeys(name);
        }
        catch (Exception e) 
        {
            _loggerService.LogError(e, "An error occurred while sending keys to widget name input.", _widgetNameInputLocator);
            throw; 
        }
    }

    private void ClickOnAddWidget()
    {
        try
        {
            _webDriver.WaitUntilElementIsClickable(_addWidgetButtonLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            AddWidgetButton.Click();
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "An error occurred while clicking on add widget button.", _addWidgetButtonLocator);
            throw; 
        }
    }

    private void WaitForWidgetsCountToBe(int count)
    {
        Func<IWebDriver, bool> waitForWidgets = driver =>
                driver.FindElements(_widgetNamesLocator).Count == count;

        _webDriver.WaitForCondition(waitForWidgets,
        _webDriverService.GetWebDriverConfiguration().LongTimeout,
        _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);
    }
}
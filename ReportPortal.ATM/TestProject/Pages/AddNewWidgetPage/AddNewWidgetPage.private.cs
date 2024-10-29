using OpenQA.Selenium;
using System;
using WebDriverLibrary.Extensions.WebDrivers;

namespace TestProject.Pages.AddNewWidgetPage;

public partial class AddNewWidgetPage
{
    private void SelectWidget(string type)
    {
        try
        {
            WidgetTypeInput(type).Click();
        }
        catch (Exception e) { throw; }
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
        catch (Exception e) { throw; }
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
        catch (Exception e) { throw; }
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
        catch (Exception e) { throw; }
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
        catch (Exception e) { throw; }
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

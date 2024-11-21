using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WebDriverLibrary.Extensions.Helpers;
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

            _webDriver.ScrollToElement(DeleteButton);

            DeleteButton.Click();
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "An error occurred while clicking on delete dashboard button.",
                _deleteButtonLoocator);
            throw;
        }
    }

    private void ClickOnConfirmDeleteButton()
    {
        try
        {
            _webDriver.WaitUntilElementIsClickable(_confirmDeleteButtonLoocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            _webDriver.ScrollToElement(ConfirmDeleteButton);

            ConfirmDeleteButton.Click();
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "An error occurred while clicking on confirm delete dashboard button.",
                _confirmDeleteButtonLoocator);
            throw;
        }
    }

    private void ClickOnAddWidgetButton()
    {
        try
        {
            _webDriver.WaitUntilElementIsClickable(_addWidgetButtonLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            _webDriver.ScrollToElement(AddWidgetButton);

            AddWidgetButton.Click();
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "An error occurred while clicking on add widget button.", _addWidgetButtonLocator);
            throw;
        }
    }

    private void WaitForWidgetNames()
    {
        try
        {
            _webDriver.WaitUntilElementExists(_widgetNamesLocator,
            _webDriverService.GetWebDriverConfiguration().LongTimeout,
            _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "An error occurred while waiting for widget names to exist.", _widgetNamesLocator);
            throw;
        }
    }

    private void WaitForWidgetTypes()
    {
        try
        {
            _webDriver.WaitUntilElementExists(_widgetTypesLocator,
            _webDriverService.GetWebDriverConfiguration().LongTimeout,
            _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "An error occurred while waiting for widget types to exist.", _widgetTypesLocator);
            throw;
        }
    }

    private void MoveWidgetOffset(string widgetName)
    {
        try
        {
            WaitForWidgetNames();
            var widgetContainer = GetWidgetHeaderByName(widgetName);
            _webDriver.DragAndDrop(widgetContainer);
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "An error occurred while moving widget.", widgetName);
            throw;
        }
    }

    private IList<int> GetWidgetTransaleValues(IWebElement widgetContainer)
    {
        ArgumentNullException.ThrowIfNull(widgetContainer);
        try
        {
            var containerStyleValue = widgetContainer.GetAttribute("style");

            Regex regex = new Regex(@"translate\((\d+)px,\s*(\d+)px\)");
            Match match = regex.Match(containerStyleValue);

            var x = int.Parse(match.Groups[1].Value);
            var y = int.Parse(match.Groups[2].Value);

            return new List<int> { x, y };
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, "An error occurred while getting widget container translate values."
                , _widgetGridContainerLocator);
            throw;
        }
    }

    private IWebElement GetWidgetContainerByName(string name)
    {
        try
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            WaitForWidgetNames();

            return WidgetNames
                .First(widget => widget.Text.Equals(name, StringComparison.OrdinalIgnoreCase))
                .FindElement(_widgetGridContainerLocator);
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, $"An error occurred while getting widget container by name {name}."
                , _widgetGridContainerLocator);
            throw;
        }
    }

    private IWebElement GetWidgetHeaderByName(string name)
    {
        try
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            WaitForWidgetNames();

            return WidgetNames
                .First(widget => widget.Text.Equals(name, StringComparison.OrdinalIgnoreCase))
                .FindElement(_widgetHeaderLocator);
        }
        catch (Exception e)
        {
            _loggerService.LogError(e, $"An error occurred while getting widget header by name {name}."
                , _widgetHeaderLocator);
            throw;
        }
    }
}
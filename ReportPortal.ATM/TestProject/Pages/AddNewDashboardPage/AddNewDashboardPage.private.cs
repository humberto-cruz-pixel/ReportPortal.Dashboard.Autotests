using OpenQA.Selenium;
using System;
using WebDriverLibrary.Extensions.WebDrivers;

namespace TestProject.Pages.AddNewDashboardPage;

public partial class AddNewDashboardPage
{
    private void ClickOnAdd()
    {
        try
        {
            _webDriver.WaitUntilElementIsClickable(_addButtonLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            AddButton.Click();
        }
        catch (Exception e) 
        {
            _loggerService.LogError(e, "An error occurred while clicking on add new dashboard button", _addButtonLocator);
            throw;
        }
    }

    private void NameClearAndSendKeys(string name)
    {
        try
        {
            _webDriver.WaitUntilElementIsVisible(_nameInputLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            NameInput.Clear();
            NameInput.SendKeys(name);
        }
        catch (Exception e) 
        {
            _loggerService.LogError(e, "An error occurred while sending keys to dashboard name input.", _nameInputLocator);
            throw; 
        }
    }

    private void DescriptionClearAndSendKeys(string description)
    {
        try
        {
            _webDriver.WaitUntilElementIsVisible(_descriptionInputLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            DescriptionInput.Clear();
            DescriptionInput.SendKeys(description);
        }
        catch (Exception e) 
        {
            _loggerService.LogError(e, "An error occurred while sending keys to dashboard description input.", _descriptionInputLocator);
            throw; 
        }
    }
}

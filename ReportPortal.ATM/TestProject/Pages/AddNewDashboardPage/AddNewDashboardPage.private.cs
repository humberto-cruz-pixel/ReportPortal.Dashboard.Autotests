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
        catch (Exception e) { throw; }
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
        catch (Exception e) { throw; }
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
        catch (Exception e) { throw; }
    }
}

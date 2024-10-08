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
}

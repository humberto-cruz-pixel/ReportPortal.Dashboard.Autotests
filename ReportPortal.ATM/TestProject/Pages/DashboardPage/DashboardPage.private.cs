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
}

using System;
using WebDriverLibrary.Extensions.WebDrivers;

namespace TestProject.Pages.LoginPage;

public partial class LoginPage
{
    private void ClickOnLoginButton()
    {
        try
        {
            _webDriver.WaitUntilElementIsClickable(_logInButtonLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            LogInButton.Click();
        }
        catch (Exception e) { throw; }
    }
}

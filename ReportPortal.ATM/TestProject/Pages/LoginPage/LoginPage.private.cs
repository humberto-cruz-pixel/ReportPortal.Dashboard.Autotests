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
        catch (Exception e) 
        {
            _loggerService.LogError(e, "An error occurred while clicking login button.", _logInButtonLocator);
            throw; 
        }
    }

    private void UserInputClearAndSendKeys(string user)
    {
        try
        {
            _webDriver.WaitUntilElementExists(_userInputLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            UserInput.Clear();
            UserInput.SendKeys(user);
        }
        catch (Exception e) 
        {
            _loggerService.LogError(e, "An error occurred while sending keys to username input.", _userInputLocator);
            throw; 
        }
    }

    private void PasswordInputClearAndSendKeys(string password)
    {
        try
        {
            _webDriver.WaitUntilElementExists(_passwordInputLocator,
                _webDriverService.GetWebDriverConfiguration().LongTimeout,
                _webDriverService.GetWebDriverConfiguration().PollingIntervalTimeout);

            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
        }
        catch (Exception e) 
        {
            _loggerService.LogError(e, "An error occurred while sending keys to password input.", _passwordInputLocator);
            throw; 
        }
    }
}
using OpenQA.Selenium;
using System;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Pages.LoginPage;

public partial class LoginPage
{
    private readonly IWebDriverService _webDriverService;
    private readonly IWebDriver _webDriver;

    public LoginPage(IWebDriverService webDriverService)
    {
        ArgumentNullException.ThrowIfNull(webDriverService);

        _webDriverService = webDriverService;
        _webDriver = _webDriverService.GetWebDriver();
    }

    public void LogIn(string user, string password)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(user);
        ArgumentException.ThrowIfNullOrWhiteSpace(password);

        UserInputClearAndSendKeys(user);
        PasswordInputClearAndSendKeys(password);
        ClickOnLoginButton();
    }
}

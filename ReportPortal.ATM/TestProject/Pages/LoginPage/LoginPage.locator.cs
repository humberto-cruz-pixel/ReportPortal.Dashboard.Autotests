using OpenQA.Selenium;

namespace TestProject.Pages.LoginPage;

public partial class LoginPage
{
    private readonly By _userInputLocator = By.XPath("//input[@class='inputOutside__input--Ad7Xu'] [@name='login']");
    private readonly By _passwordInputLocator = By.XPath("//input[@class='inputOutside__input--Ad7Xu'] [@name='password']");
    private readonly By _logInButtonLocator = By.XPath("//button[text()='Login']");

    private IWebElement UserInput => _webDriver.FindElement(_userInputLocator);
    private IWebElement PasswordInput => _webDriver.FindElement(_passwordInputLocator);
    private IWebElement LogInButton => _webDriver.FindElement(_logInButtonLocator);
}

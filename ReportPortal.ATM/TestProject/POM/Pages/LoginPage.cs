using OpenQA.Selenium;
using TestProject.POM.Elements;

namespace TestProject.POM.Pages;

public class LoginPage : BasePage
{
    private readonly By _userInputLocator = By.XPath("//input[@class='inputOutside__input--Ad7Xu'] [@name='login']");
    private readonly By _passwordInputLocator = By.XPath("//input[@class='inputOutside__input--Ad7Xu'] [@name='password']");

    public LoginPage(IWebDriver webDriver) : base(webDriver)
    {
    }

    public Input UserInput => new(Driver, _userInputLocator);
    public Input PasswordInput => new(Driver, _passwordInputLocator);

    public void LogIn(string user, string password)
    {   
        UserInput.ClearAndSendKeys(user);
        PasswordInput.ClearAndSendKeys(password);
    }
}

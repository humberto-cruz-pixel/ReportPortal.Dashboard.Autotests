using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestProject.Models;
using TestProject.POM.Pages;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Hooks;

[Binding]
public class LoginFeatureSteps
{
    private readonly LoginPage _loginPage;
    private readonly Enviroment _enviroment;

    public LoginFeatureSteps()
    {
        var webDriver = (IWebDriver)ScenarioContext.Current["webDriver"];

        var webDriverService = (IWebDriverService)ScenarioContext.Current["webDriverService"];

        _enviroment = (Enviroment)ScenarioContext.Current["enviroment"];

        webDriverService.NavigateTo(_enviroment.URL);

        _loginPage = new LoginPage(webDriver);
    }

    [Given("I log in to ReportPortal")]
    public void LoginToReportPortal()
    {
        _loginPage.LogIn(_enviroment.UserName, _enviroment.Password);
    }
}

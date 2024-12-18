using LoggerLibrary.Interfaces.Loggers;
using System;
using TechTalk.SpecFlow;
using TestProject.Models;
using TestProject.Pages.LoginPage;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Steps;

[Binding]
public class LoginFeatureSteps
{
    private readonly LoginPage _loginPage;
    private readonly Enviroment _enviroment;
    private readonly ScenarioContext _scenarioContext;
    private readonly string _userName;
    private readonly string _password;

    public LoginFeatureSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;

        var webDriverService = _scenarioContext["webDriverService"] as IWebDriverService;

        _enviroment = _scenarioContext["enviroment"] as Enviroment;

        webDriverService!.NavigateTo(_enviroment!.URL);
        
        var loggerService = _scenarioContext["loggerService"] as ILoggerService;

        _loginPage = new LoginPage(webDriverService, loggerService!);

        _userName = Environment.GetEnvironmentVariable("USER_NAME")!;

        _password = Environment.GetEnvironmentVariable("PASSWORD")!;
    }

    [Given("I log in to ReportPortal")]
    public void LoginToReportPortal()
    {
        _loginPage.LogIn(_userName, _password);
    }


}

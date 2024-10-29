﻿using TechTalk.SpecFlow;
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

    public LoginFeatureSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;

        var webDriverService = _scenarioContext["webDriverService"] as IWebDriverService;

        _enviroment = _scenarioContext["enviroment"] as Enviroment;

        webDriverService.NavigateTo(_enviroment.URL);

        _loginPage = new LoginPage(webDriverService);
    }

    [Given("I log in to ReportPortal")]
    public void LoginToReportPortal()
    {
        _loginPage.LogIn(_enviroment.UserName, _enviroment.Password);
    }


}
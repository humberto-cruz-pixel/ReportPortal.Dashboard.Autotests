using ConfigurationLibrary.Interfaces.Configuration;
using FrameworkFacade.FrameworkStartup;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechTalk.SpecFlow;
using TestProject.Models;
using WebDriverLibrary.Interfaces.WebDrivers;
using WebDriverLibrary.WebDrivers;

namespace TestProject.Hooks;

[Binding]
public sealed class ScenarioHook
{
    private readonly IServiceProvider _frameworkService;
    private readonly Enviroment _enviroment;

    public ScenarioHook()
    {
        _frameworkService = new FrameworkService("\\ReportPortal.ATM\\TestProject\\", "Settings.json")
            .GetServiceProvider();

        _enviroment = new Enviroment(_frameworkService
            .GetRequiredService<IConfigurationService>());
    }

    [BeforeFeature]
    public static void GlobalSetup()
    {
    }

    [BeforeScenario]
    public void Setup()
    {
        ScenarioContext.Current["enviroment"] = _enviroment;

        var webDriverService = _frameworkService.GetRequiredService<IWebDriverService>();

        ScenarioContext.Current["webDriverService"] = webDriverService;

        ScenarioContext.Current["webDriver"] = webDriverService.GetWebDriver();
    }

    [AfterScenario]
    public void TearDown()
    {
        var webDriverService = (SeleniumWebDriverService)ScenarioContext.Current["webDriverService"];

        webDriverService.DisposeWebDriver();
    }

    [AfterTestRun]
    public void Dispose()
    {
        _frameworkService.CreateScope().Dispose();
    }
}

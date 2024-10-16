using ConfigurationLibrary.Interfaces.Configuration;
using FrameworkFacade.FrameworkStartup;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
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
        _frameworkService = new FrameworkService(Directory.GetCurrentDirectory(), "Settings.json")
            .GetServiceProvider().CreateScope().ServiceProvider;

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

        ScenarioContext.Current["webDriverService"] = _frameworkService.GetRequiredService<IWebDriverService>(); ;
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

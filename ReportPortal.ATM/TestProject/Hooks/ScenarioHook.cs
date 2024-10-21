using ConfigurationLibrary.Interfaces.Configuration;
using FrameworkFacade.FrameworkStartup;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TechTalk.SpecFlow;
using TestProject.Models;
using WebDriverLibrary.Interfaces.WebDrivers;
using WebDriverLibrary.WebDrivers;

namespace TestProject.Hooks;

[Binding]
public sealed class ScenarioHook
{
    private readonly IServiceScope _frameworkScope;
    private readonly Enviroment _enviroment;

    public ScenarioHook()
    {
        _frameworkScope = new FrameworkService(Directory.GetCurrentDirectory(), "appsettings.json")
            .GetServiceProvider().CreateScope();

        _enviroment = new Enviroment(_frameworkScope.ServiceProvider
            .GetRequiredService<IConfigurationService>());
    }

    [BeforeScenario]
    public void Setup(ScenarioContext scenarioContext)
    {
        scenarioContext["enviroment"] = _enviroment;

        scenarioContext["webDriverService"] = _frameworkScope.ServiceProvider.GetRequiredService<IWebDriverService>();

        scenarioContext["frameworkScope"] = _frameworkScope;
    }

    [AfterScenario]
    public void AfterScenario(ScenarioContext scenarioContext)
    {
        var webDriverService = (SeleniumWebDriverService)scenarioContext["webDriverService"];

        webDriverService.DisposeWebDriver();

        _frameworkScope.Dispose();
    }
}

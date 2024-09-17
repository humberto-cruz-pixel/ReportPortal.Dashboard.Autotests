using ConfigurationLibrary.Interfaces.Configuration;
using FrameworkFacade.FrameworkStartup;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;
using TestProject.Models;
using WebDriverLibrary.Interfaces.WebDrivers;
using WebDriverLibrary.WebDrivers;

namespace TestProject.Hooks;

[Binding]
public sealed class ScenarioHook
{
    private  FrameworkService _frameworkService;
    private  Enviroment _enviroment;

    public ScenarioHook()
    {
        _frameworkService = new FrameworkService("\\ReportPortal.ATM\\TestProject\\", "Settings.json");

        _enviroment = new Enviroment(_frameworkService.GetServiceProvider()
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

        var webDriverService = _frameworkService.GetServiceProvider().GetRequiredService<IWebDriverService>();

        ScenarioContext.Current["webDriverService"] = webDriverService;

        ScenarioContext.Current["webDriver"] = webDriverService.GetWebDriver();
    }

    [AfterScenario]
    public void TearDown()
    {
        var webDriverService = (SeleniumWebDriverService)ScenarioContext.Current["webDriverService"];

        webDriverService.DisposeWebDriver();
    }
}

using ConfigurationLibrary.Interfaces.Configuration;
using FrameworkFacade.FrameworkStartup;
using LoggerLibrary.Interfaces.Factories;
using LoggerLibrary.Interfaces.Loggers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using TechTalk.SpecFlow;
using TestProject.Models;
using TestProject.Structs;
using WebDriverLibrary.Interfaces.WebDrivers;
using WebDriverLibrary.WebDrivers;

namespace TestProject.Hooks;

[Binding]
public sealed class ScenarioHook
{
    private readonly IServiceScope _frameworkScope;
    private readonly Enviroment _enviroment;
    private readonly ILoggerService _loggerService;

    public ScenarioHook()
    {
        var scenarioId = Guid.NewGuid().ToString();

        var fullFilePath = $"{ConfigurationKey.LogFilePath}\\{scenarioId}.txt";

        _frameworkScope = new FrameworkService(Directory.GetCurrentDirectory(), "appsettings.json")
            .GetServiceProvider().CreateScope();

        _enviroment = new Enviroment(_frameworkScope.ServiceProvider
            .GetRequiredService<IConfigurationService>());

        _loggerService = _frameworkScope.ServiceProvider.GetRequiredService<ILoggerServiceFactory>()
            .CreateLoggerService(fullFilePath);

        DotNetEnv.Env.Load(Directory.GetCurrentDirectory() + "\\Enviroment.env");
    }

    [BeforeScenario]
    public void Setup(ScenarioContext scenarioContext)
    {
        scenarioContext["enviroment"] = _enviroment;

        scenarioContext["webDriverService"] = _frameworkScope.ServiceProvider.GetRequiredService<IWebDriverService>();

        scenarioContext["frameworkScope"] = _frameworkScope;

        scenarioContext["loggerService"] = _loggerService;

        _loggerService.LogInformation($"Initializing Scenario: {scenarioContext.ScenarioInfo.Title}");
    }

    [BeforeStep]
    public static void BeforeStep(ScenarioContext scenarioContext)
    {
        var logger = scenarioContext["loggerService"] as ILoggerService;
        var definitionType = scenarioContext.StepContext.StepInfo.StepDefinitionType;
        var stepText = scenarioContext.StepContext.StepInfo.Text;

        logger!.LogInformation($"{definitionType} {stepText}");
    }

    [AfterStep]
    public static void AfterStep(ScenarioContext scenarioContext)
    {
        var logger = scenarioContext["loggerService"] as ILoggerService;

        var status = scenarioContext.StepContext.Status;
        var definitionType = scenarioContext.StepContext.StepInfo.StepDefinitionType;
        var stepText = scenarioContext.StepContext.StepInfo.Text;

        var message = $"{definitionType} {stepText}\n";

        var exception = scenarioContext.TestError;

        LogOutcome(logger!, message, status, exception);
    }

    private static void LogOutcome(ILoggerService logger, string message, ScenarioExecutionStatus status, Exception exception)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentException.ThrowIfNullOrWhiteSpace(message);

        var logMessage = $"\t{status} - {message}";

        switch (status)
        {
            case ScenarioExecutionStatus.OK:
                logger.LogInformation(logMessage);
                break;

            case ScenarioExecutionStatus.TestError:
                logger.LogError(exception, logMessage);
                break;

            case ScenarioExecutionStatus.StepDefinitionPending:
                logger.LogWarning(logMessage);
                break;

            case ScenarioExecutionStatus.UndefinedStep:
                logger.LogWarning(logMessage);
                break;

            case ScenarioExecutionStatus.BindingError:
                logger.LogError(exception, logMessage);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(status), status, null);
        }
    }

    [AfterScenario]
    public void AfterScenario(ScenarioContext scenarioContext)
    {
        var webDriverService = (SeleniumWebDriverService)scenarioContext["webDriverService"];

        webDriverService.DisposeWebDriver();

        _frameworkScope.Dispose();

        _loggerService.CloseAndFlush();
    }
}
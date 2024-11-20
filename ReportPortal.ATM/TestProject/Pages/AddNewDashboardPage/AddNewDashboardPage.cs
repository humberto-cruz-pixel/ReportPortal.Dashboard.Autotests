using LoggerLibrary.Interfaces.Loggers;
using OpenQA.Selenium;
using System;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Pages.AddNewDashboardPage;

public partial class AddNewDashboardPage
{
    private readonly IWebDriverService _webDriverService;
    private readonly IWebDriver _webDriver;
    private readonly ILoggerService _loggerService;

    public AddNewDashboardPage(IWebDriverService webDriverService, ILoggerService loggerService)
    {

        ArgumentNullException.ThrowIfNull(webDriverService);

        _webDriverService = webDriverService;
        _webDriver = _webDriverService.GetWebDriver();
        _loggerService = loggerService;

        _loggerService.LogInformation("Add New Dashboard Page instantiation complete");
    }

    public void AddNewDashboard(string name, string description)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(description);

        NameClearAndSendKeys(name);
        DescriptionClearAndSendKeys(description);
        ClickOnAdd();
    }
}

using ConfigurationLibrary.Interfaces.Configuration;
using FrameworkFacade.FrameworkStartup;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TestProject.Interfaces.Models.Dashboard;
using TestProject.Models;
using TestProject.Models.Dashboard;
using TestProject.Pages.AddNewDashboardPage;
using TestProject.Pages.AllDashboardPage;
using TestProject.Pages.DashboardPage;
using TestProject.Pages.LoginPage;
using TestProject.Pages.NavBar;
using TestProject.Structs;
using WebDriverLibrary.Interfaces.WebDrivers;
using Xunit;

namespace TestProject.Tests.XUnit;

public class CreateAndEditDashboards
{

    private readonly Enviroment _enviroment;
    private readonly IWebDriverService _driverService;
    private readonly LoginPage _loginPage;
    private readonly AllDashboardsPage _allDashboardsPage;
    private readonly AddNewDashboardPage _addNewDashboardPage;
    private readonly NavBarPage _navBarPage;
    private readonly DashboardPage _dashboardPage;
    private readonly IServiceScope _serviceScope;


    public CreateAndEditDashboards()
    {
        _serviceScope = new FrameworkService(Directory.GetCurrentDirectory(), ConfigurationKey.ConfigurationFileName)
        .GetServiceProvider().CreateScope();
        _enviroment = new Enviroment(_serviceScope.ServiceProvider
        .GetRequiredService<IConfigurationService>());

        _driverService = _serviceScope.ServiceProvider.GetRequiredService<IWebDriverService>();
        _driverService.NavigateTo(_enviroment.URL);

        _loginPage = new LoginPage(_driverService);
        _allDashboardsPage = new AllDashboardsPage(_driverService);
        _addNewDashboardPage = new AddNewDashboardPage(_driverService);
        _navBarPage = new NavBarPage(_driverService);
        _dashboardPage = new DashboardPage(_driverService);
    }

    [Xunit.Theory]
    [MemberData(nameof(TestDataLoaderXUnit<DashboardCreation>.LoadTestData), "TestData\\Models\\Dashboard\\DashboardCreation.json", MemberType = typeof(TestDataLoaderXUnit<DashboardCreation>))]
    public void CreateNewDashboard(IDashboardCreation dashboardCreation)
    {
        _loginPage.LogIn(_enviroment.UserName, _enviroment.Password);

        _allDashboardsPage.OpenCreateNewDashboard();

        _addNewDashboardPage.AddNewDashboard(dashboardCreation.Name, dashboardCreation.Description);

        _navBarPage.OpenDashboardsPage();

        _allDashboardsPage.CheckDashboardName(dashboardCreation.Name);
        _allDashboardsPage.CheckDashboardDescription(dashboardCreation.Description);

        _allDashboardsPage.OpenDashboard(dashboardCreation.Name);

        _dashboardPage.DeleteDashboard();

        TearDown();
    }

    [Xunit.Theory]
    [MemberData(nameof(TestDataLoaderXUnit<DashboardCreation>.LoadTestData), "TestData\\Models\\Dashboard\\DashboardCreation.json", MemberType = typeof(TestDataLoaderXUnit<DashboardCreation>))]
    public void EditDashboard(IDashboardCreation dashboardCreation)
    {
        _loginPage.LogIn(_enviroment.UserName, _enviroment.Password);

        _allDashboardsPage.OpenCreateNewDashboard();

        _addNewDashboardPage.AddNewDashboard(dashboardCreation.Name, dashboardCreation.Description);

        _navBarPage.OpenDashboardsPage();

        _allDashboardsPage.OpenEditDashboard();

        _addNewDashboardPage.AddNewDashboard(dashboardCreation.Description, dashboardCreation.Name);

        _navBarPage.OpenDashboardsPage();

        _allDashboardsPage.CheckDashboardName(dashboardCreation.Description);
        _allDashboardsPage.CheckDashboardDescription(dashboardCreation.Name);

        _allDashboardsPage.OpenDashboard(dashboardCreation.Description);

        _dashboardPage.DeleteDashboard();

        TearDown();
    }

    internal void TearDown()
    {
        _driverService.DisposeWebDriver();
        _serviceScope.Dispose();
    }

}

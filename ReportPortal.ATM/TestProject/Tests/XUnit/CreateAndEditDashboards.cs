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

    private Enviroment _enviroment;
    private IWebDriverService _driverService;
    private LoginPage _loginPage;
    private AllDashboardsPage _allDashboardsPage;
    private AddNewDashboardPage _addNewDashboardPage;
    private NavBarPage _navBarPage;
    private DashboardPage _dashboardPage;

    public CreateAndEditDashboards()
    {
        var serviceProvider = new FrameworkService(Directory.GetCurrentDirectory(), ConfigurationKey.ConfigurationFileName)
        .GetServiceProvider().CreateScope().ServiceProvider;
        _enviroment = new Enviroment(serviceProvider
        .GetRequiredService<IConfigurationService>());

        _driverService = serviceProvider.GetRequiredService<IWebDriverService>();
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

        _addNewDashboardPage.AddNewDashboard(dashboardCreation.name, dashboardCreation.description);

        _navBarPage.OpenDashboardsPage();

        _allDashboardsPage.CheckDashboardExists(dashboardCreation.name, dashboardCreation.description);

        _allDashboardsPage.OpenDashboard(dashboardCreation.name);

        _dashboardPage.DeleteDashboard();

        TearDown();
    }

    [Xunit.Theory]
    [MemberData(nameof(TestDataLoaderXUnit<DashboardCreation>.LoadTestData), "TestData\\Models\\Dashboard\\DashboardCreation.json", MemberType = typeof(TestDataLoaderXUnit<DashboardCreation>))]
    public void EditDashboard(IDashboardCreation dashboardCreation)
    {
        _loginPage.LogIn(_enviroment.UserName, _enviroment.Password);

        _allDashboardsPage.OpenCreateNewDashboard();

        _addNewDashboardPage.AddNewDashboard(dashboardCreation.name, dashboardCreation.description);

        _navBarPage.OpenDashboardsPage();

        _allDashboardsPage.OpenEditDashboard();

        _addNewDashboardPage.AddNewDashboard(dashboardCreation.description, dashboardCreation.name);

        _navBarPage.OpenDashboardsPage();

        _allDashboardsPage.CheckDashboardExists(dashboardCreation.description, dashboardCreation.name);

        _allDashboardsPage.OpenDashboard(dashboardCreation.description);

        _dashboardPage.DeleteDashboard();

        TearDown();
    }

    public void TearDown()
    {
        _driverService.DisposeWebDriver();
    }

}

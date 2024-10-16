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
using TestProject.TestData;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Tests.NUnit;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateAndEditDashboard
{
    private Enviroment _enviroment;
    private IWebDriverService _driverService;
    private LoginPage _loginPage;
    private AllDashboardsPage _allDashboardsPage;
    private AddNewDashboardPage _addNewDashboardPage;
    private NavBarPage _navBarPage;
    private DashboardPage _dashboardPage;
    private IServiceScope _serviceScope;

    public CreateAndEditDashboard()
    {
    }

    [SetUp]
    public void Setup()
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


    [Test, TestCaseSource(typeof(TestDataLoaderNunit<DashboardCreation>), nameof(TestDataLoaderNunit<DashboardCreation>.LoadTestData), new object[] { "TestData\\Models\\Dashboard\\DashboardCreation.json" })]
    public void CreateNewDashbord(IDashboardCreation dashboardCreation)
    {
        _loginPage.LogIn(_enviroment.UserName, _enviroment.Password);

        _allDashboardsPage.OpenCreateNewDashboard();

        _addNewDashboardPage.AddNewDashboard(dashboardCreation.Name, dashboardCreation.Description);

        _navBarPage.OpenDashboardsPage();

        _allDashboardsPage.CheckDashboardName(dashboardCreation.Name);
        _allDashboardsPage.CheckDashboardDescription(dashboardCreation.Description);

        _allDashboardsPage.OpenDashboard(dashboardCreation.Name);

        _dashboardPage.DeleteDashboard();
    }


    [Test, TestCaseSource(typeof(TestDataLoaderNunit<DashboardCreation>), nameof(TestDataLoaderNunit<DashboardCreation>.LoadTestData), new object[] { "TestData\\Models\\Dashboard\\DashboardCreation.json" })]
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
    }

    [TearDown]
    public void TearDown()
    {
        _driverService.DisposeWebDriver();
        _serviceScope.Dispose();
    }
}
using TechTalk.SpecFlow;
using TestProject.Pages.AddNewDashboardPage;
using TestProject.Pages.AllDashboardPage;
using TestProject.Pages.DashboardPage;
using TestProject.Pages.NavBar;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Steps;

[Binding]
public class CreateAndEditDashboardFeatureSteps
{
    private readonly AllDashboardsPage _allDashboardsPage;
    private readonly AddNewDashboardPage _addNewDashboardPage;
    private readonly NavBarPage _navBarPage;
    private readonly DashboardPage _dashboardPage;
    private readonly ScenarioContext _scenarioContext;

    public CreateAndEditDashboardFeatureSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;

        var driverService = _scenarioContext["webDriverService"] as IWebDriverService;

        _allDashboardsPage = new AllDashboardsPage(driverService);
        _addNewDashboardPage = new AddNewDashboardPage(driverService);
        _navBarPage = new NavBarPage(driverService);
        _dashboardPage = new DashboardPage(driverService);
    }

    [Given(@"I navigate to all dashboards page")]
    [When(@"I navigate to all dashboards page")]
    public void GivenINavigateToAllDashboardsPage()
    {
        _navBarPage.OpenDashboardsPage();

    }

    [When(@"I click on add new dashboard")]
    public void WhenIClickOnAddNewDashboard()
    {
        _allDashboardsPage.OpenCreateNewDashboard();
    }

    [When(@"I enter dashboard (.*) and (.*)")]
    public void WhenIEnterNameAndDescription(string name, string description)
    {
        _scenarioContext["dashboardName"] = name;
        _scenarioContext["dashboardDescription"] = description;

        _addNewDashboardPage.AddNewDashboard(name, description);
    }

    [Then(@"edited dashboard should be on all dashboards page")]
    [Then(@"created dashboard should be on all dashboards page")]
    public void ThenCreatedDashboardShouldBeOnAllDashboardsPage()
    {
        var name = _scenarioContext["dashboardName"] as string;
        var description = _scenarioContext["dashboardDescription"] as string;

        _allDashboardsPage.CheckDashboardName(name);
        _allDashboardsPage.CheckDashboardDescription(description);

        WhenDeleteDashboard(name);
    }

    [When(@"I click on edit dashboard")]
    public void WhenIClickOnEditDashboard()
    {
        _allDashboardsPage.OpenEditDashboard();
    }

    [When(@"I delete dashboard (.*)")]
    public void WhenDeleteDashboard(string name)
    {
        _allDashboardsPage.OpenDashboard(name);

        _dashboardPage.DeleteDashboard();
    }
}

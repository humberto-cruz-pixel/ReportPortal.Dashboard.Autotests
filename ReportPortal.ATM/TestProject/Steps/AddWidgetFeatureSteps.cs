using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TestProject.Pages.AddNewWidgetPage;
using TestProject.Pages.DashboardPage;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace TestProject.Steps;

[Binding]

public class AddWidgetFeatureSteps
{

    private readonly AddNewWidgetPage _addWidgetPage;
    private readonly DashboardPage _dashboardPage;
    private readonly ScenarioContext _scenarioContext;
    private readonly IList<string> _widgetNames;
    private readonly IList<string> _widgetTypes;
    private int widgetCount;

    public AddWidgetFeatureSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        var driverService = _scenarioContext["webDriverService"] as IWebDriverService;

        _addWidgetPage = new AddNewWidgetPage(driverService);
        _dashboardPage = new DashboardPage(driverService);

        _widgetNames = new List<string>();
        _widgetTypes = new List<string>();
    }

    [When(@"I click on add a widget")]
    public void WhenIEnterDashboardNameAndDescription()
    {
        _dashboardPage.OpenAddWidget();
    }

    [When(@"I Add (.*) widget type and enter a random name")]
    public void WhenISelectWidgetType(string type)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(type);

        var guidName = Guid.NewGuid().ToString("N");

        widgetCount++;

        _addWidgetPage.AddNewWidget(type, guidName, widgetCount);

        _widgetNames.Add(guidName);
        _widgetTypes.Add(type);
    }

    [Then(@"Added widgets should be on dashboard page")]
    [Then(@"Added widget should be on dashboard page")]
    public void ThenAddedWidgetShouldBeOnDashboardPage()
    {
        var actualWidgetNames = _dashboardPage.GetWidgetNames();
        var actualWidgetTypes = _dashboardPage.GetWidgetTypes();

        Assert.Multiple(() =>
        {
            foreach (var widgetName in actualWidgetNames)
            {
                Assert.That(_widgetNames.Contains(widgetName));
            }

            foreach (var widgetType in actualWidgetTypes)
            {
                Assert.That(_widgetTypes.Contains(widgetType));
            }
        });
        _dashboardPage.DeleteDashboard();
    }
}
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
    private IList<string> widgetNames;
    private IList<string> widgetTypes;

    public AddWidgetFeatureSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        var driverService = _scenarioContext["webDriverService"] as IWebDriverService;

        _addWidgetPage = new AddNewWidgetPage(driverService);
        _dashboardPage = new DashboardPage(driverService);

        widgetNames = new List<string>();
        widgetTypes = new List<string>();
    }

    [When(@"I click on add a widget")]
    public void WhenIEnterDashboardNameAndDescription()
    {
        _dashboardPage.OpenAddWidget();
    }

    [When(@"I Add (.*) widget type and enter (.*) name")]
    public void WhenISelectWidgetType(string type, string name)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(type);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(name);

        _addWidgetPage.AddNewWidget(type, name);

        widgetNames.Add(name);
        widgetTypes.Add(type);
    }

    [Then(@"Added widgets should be on dashboard page")]
    [Then(@"Added widget should be on dashboard page")]
    public void ThenAddedWidgetShouldBeOnDashboardPage()
    {
        foreach (var name in widgetNames)
            _dashboardPage.IsWidgetNameInDashboard(name);

        foreach (var type in widgetTypes)
            _dashboardPage.IsWidgetTypeInDashboard(type);

        _dashboardPage.DeleteDashboard();
    }
}

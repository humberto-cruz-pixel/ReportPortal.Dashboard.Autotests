Feature: Dashboard Add Widget feature

User is able to add widget to dashboard

@Smoke
Scenario: Verify the user can add a widget to dashboard
	Given I log in to ReportPortal
	And I navigate to all dashboards page
	When I click on add new dashboard
	And I enter dashboard Test and Hola
	And I click on add a widget
	And I Add Launch statistics chart widget type and enter TestWidget name
	And I click on add a widget
	And I Add Overall statistics widget type and enter TestWidget2 name
	Then Added widgets should be on dashboard page

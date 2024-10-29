Feature: Dashboard Creation and Edit feature

User is able to create/edit a dashboard via UI

Background:
	Given I log in to ReportPortal
	And I navigate to all dashboards page
	When I click on add new dashboard

@Smoke
Scenario Outline: Verify the user can create a new dashboard
	When I enter dashboard <name> and <description>
	And I navigate to all dashboards page
	Then created dashboard should be on all dashboards page
	Examples: 
	| name  | description |
	| test  | hola1       |
	| test2 | hola2       |

@Smoke
Scenario Outline: Verify the user can edit a dashboard
	When I enter dashboard dashboard and description
	And I navigate to all dashboards page
	And I click on edit dashboard
	And I enter dashboard <name> and <description>
	And I navigate to all dashboards page
	Then edited dashboard should be on all dashboards page
	Examples: 
	| name  | description |
	| testName  | Description1       |
	| testName2 | Description2       |
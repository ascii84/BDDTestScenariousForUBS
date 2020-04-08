Feature: SpecFlowFeature1
	In order to get info about UBS
	I want to be able to display Our firm page

@mytag
Scenario: Display Our firm page
	Given I have opened the main page
	When I click About us
	And I choose Our firm menu item
	Then The Our firm page is displayed

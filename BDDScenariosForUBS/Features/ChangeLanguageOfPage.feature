Feature: Change the language of page to German
	In order to make UBS available for users from Germany
	I want to be able to change the language of the page to German

@mytag
Scenario: Change the language of page to German
	Given I have opened the main page
	When I click DE icon
	Then The page is displayed in Germany version

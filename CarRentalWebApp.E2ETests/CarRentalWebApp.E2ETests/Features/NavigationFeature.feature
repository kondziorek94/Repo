Feature: NavigationFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@scenario
Scenario: Go to About page
	Given I am on the home page
	And I clicked "About" button
	Then I see "About" page

Feature: NavigationFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Go to About page
	Given I am on the home page
	And I clicked "About" button
	Then I see "About" page

Scenario: Go to Contact page
	Given I am on the home page
	And I clicked "Contact" button
	Then I see "Contact" page

Scenario: Check calculator functionality
	Given I am on the home page
	And I clicked "Go to calculator" button
	Then I check the result
	
	


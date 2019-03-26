Feature: CalculatorFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Check calculator functionality
	Given I am on the home page
	And I clicked "Go to calculator" button
	Then I check if the result eqauls '2 + 5'


	//wciskam C/CE i ekran jest pusty
	//wciskam 2,3,*,5=
	//wtedy na ekranie jest 115
Feature: CalculatorFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Check calculator functionality
	Given I am on the home page
	And I click "Go to calculator" button
	And I check if the result equals to '2 + 5'
	And I click "CE" calculator buttons
	And I check if the result equals to ''
	And I click "2,3,*,5,=" calculator buttons
	Then I check if the result equals to '115'


	#wciskam C/CE i ekran jest pusty - podzie na dwa krokji
	#wciskam 2,3,*,5=
	#wtedy na ekranie jest 115
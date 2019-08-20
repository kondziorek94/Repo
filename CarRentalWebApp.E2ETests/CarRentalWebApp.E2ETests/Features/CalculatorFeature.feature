Feature: CalculatorFeature
	In order to be able to evaluate expressions
	As a user
	I would like to be able to get correct results from calculator

Scenario: Check calculator functionality
	Given I am on the home page
	And I click "Go to calculator" button
	And I check if the result equals to '2 + 5'
	And I click "CE" calculator buttons
	And I check if the result equals to ''
	And I click "2,3,*,5,=" calculator buttons
	Then I check if the result equals to '116'
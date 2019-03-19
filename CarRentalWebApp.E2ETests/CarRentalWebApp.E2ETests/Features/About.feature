#Feature: About
#	In order to avoid silly mistakes
#	As a math idiot
#	I want to be told the sum of two numbers
#
#@mytag
#Scenario: Add two numbers
#	When I have entered 50 into the calculator
#	And I have entered 70 into the calculator
#	When I press add
#	Then the result should be 120 on the screen
#
#
#
Feature: Google

Scenario Outline: Can find search results
  Given I am on the google page for <profile> and <environment>
  When I search for "BrowserStack"
  Then I should see title "BrowserStack - Google Search"
  
  Examples:
    | profile | environment |
    | single    | chrome      |
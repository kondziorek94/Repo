Feature: AddressesFeature
	In order to avoid silly mistakes


#"https://specflow.org/documentation/SpecFlow-Assist-Helpers/"
#Dokończyć test
#Rejestracja wideo przebiegu testu
Scenario: Add two numbers
	Given I am on the home page
	And I click "Log in" button
	And I enter login information:
	|Field|Value|
	|Email|a@a.pl|
	|Password|Password2@|
	And I click "Log in" button
	And I click "Go to the list" button
	And I click "Create New" link
	And I fill data information:
	| Field       | Value         |
	| CityName    | Lublin        |
	| StreetName  | Nadbystrzycka |
	| ZipCode     | 21-024        |
	| Email       | asjv          |
	| PhoneNumber | 2014321920    |
	And I check if there are "2" validation error(s)
	And I click "Create" button
	And I correct data information:
	| Field       | Value         |
	| CityName    | Lublin        |
	| StreetName  | Nadbystrzycka |
	| ZipCode     | 21-024        |
	| Email       | kbudny492@gmail.com          |
	| PhoneNumber | 923-231-432    |
	And I click "Create" button
	And I fill search information in
	| Field         | value  |
	| addressLookUp | Lublin |
	And I check if the list contain specific address
	And I delete address
	And I check if address does not exists

#ocpjonalnie wylogowuje sie
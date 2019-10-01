Feature: AddressesFeature
	In order to avoid silly mistakes

Scenario: Add two numbers
	Given I am on the home page
	And I click "Log in navbar" button
	And I enter login information:
		| Field    | Value      |
		| Email    | a@a.pl     |
		| Password | Password2@ |
	And I click "Log in" button
	And I click "Go to the list" button
	And I click "Create New" button
	And I fill data information:
		| Field           | Value         |
		| CityName        | Lublin        |
		| StreetName      | Nadbystrzycka |
		| ZipCode         | 21-024        |
		| Email           | asjv          |
		| PhoneNumber     | 2014321920    |
		| ImportanceLevel | Regular       |
	And I check if there are "2" validation error(s)
	And I correct data information:
		| Field           | Value          |
		| CityName        | Lublin         |
		| StreetName      | Nadbystrzycka  |
		| ZipCode         | 21-024         |
		| Email           | test@gmail.com |
		| PhoneNumber     | 923-231-432    |
		| ImportanceLevel | Regular        |
	And I check if there are "0" validation error(s)
	And I click "Create" button
	And I fill search information in
		| Field         | value  |
		| addressLookUp | Lublin |
	And I check if the list contain specific address "true"
	And I delete created address
	And I check if address does not exists "false"
	And I click "Log off" button
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
	#And I click "Create" button
	#And I fill search information in
	#| Field         | value  |
	#| addressLookUp | Lublin |
	#And I check if the list contain specific address



		#loguje sie na administratora
#klikam ten przycisk go to the lsit
#klikam create new
#uzupelanam dane nieporpawnie i sprawdzam czy sa 2 validation errors messages
#poprawiam dane
#klikam Create
#wpisuje w input search dane utworzonego uzytkownika tak by go znalezc
#sprawdzam czy w tabeli jest szukany uzytkownik
#klikam delelte i otwierdzami
#wpisuje w input search dane utworzonego uzytkownika tak by go znalezc
#praaczym ze w tableli nie ma szukanego uzytkownika
#ocpjonalnie wylogowuje sie
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
	Then I check if the result equals to '115'


	#wciskam C/CE i ekran jest pusty - podzie na dwa krokji
	#wciskam 2,3,*,5=
	#wtedy na ekranie jest 115

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
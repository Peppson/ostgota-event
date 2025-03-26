Feature: Client can add a user to the system
Scenario: Client adds a user to the system
	Given the user has been created
	When the client adds the user to the system
	Then the user is added to the system
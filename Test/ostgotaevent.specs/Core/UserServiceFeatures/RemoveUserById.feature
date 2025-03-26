Feature: Client can remove a user by entering the ID

Scenario: Client removes a user by calling the function with correct ID
Given The database has a user with the "<id>"
When the client tries to remove the user
Then the client recieves a bool "<result>" with success

Examples:
	| id  | result |
	| 1   | true   |
	| 99  | false  |
	| 201 | false  |
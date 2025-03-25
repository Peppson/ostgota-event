Feature: Client can check whether a user exists in the system

Scenario Outline: Client checks whether a user exists in the system
	Given the client has the username "<username>"
	When the client checks whether the user exists in the system
	Then the client is informed that the user exists is "<expectedResult>"

	Examples:
		| username    | expectedResult |
		| JeppaJogg   | false          |
		| arif        | true           |
		| testuser    | false          |
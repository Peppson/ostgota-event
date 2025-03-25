Feature: Client should be able to get a user from databas by the username. If the user does not exist, it should get null back.

Scenario: Client looks for a user from the system
	Given the client has the username "<username>" for user lookup
	When the client gets the user from the system
	Then the client gets the result "<result>"

Examples:
	| username  | result |
	| JeppaJogg | null   |
	| arif      | User   |
	| testuser  | null   |

 
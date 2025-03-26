Feature: Client can get a user by the ID.

Scenario: The client can fetch a user by searching by the userId.
Given the client has the id
When the client fetches the user
Then the client gets the user forom the search


Scenario:The client tries fetching a user by using a id that does not exist
Given the client searches for an id that does not exist
When the client tries to fetch the user
Then the client recieves null
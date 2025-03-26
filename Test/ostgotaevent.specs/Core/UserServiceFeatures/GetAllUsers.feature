Feature: The client should return a full list of all users.

Scenario: The client returns a full list of all users
Given The database contains a list of users
When the client calls the GetAllUser-function
Then the client recieves a list of all created users
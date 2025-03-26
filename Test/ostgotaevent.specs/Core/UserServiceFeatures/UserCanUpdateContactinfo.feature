Feature: User can update info, for example email, phonenumber or password

Scenario: User wants to update the phonenumber connected to the account.
Given the user exists inside the database
And the user has changed phonenumber in the client
When the user updates the info
Then the client should return a user with the new info
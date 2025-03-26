Feature: Client can fetch Event by Id

Scenario: Client searches for an event by the id and gets an event returned
Given The client know the id of the event
When the client fetches the event by id
Then the client is returned an event
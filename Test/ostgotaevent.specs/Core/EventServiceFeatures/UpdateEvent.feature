Feature: The client can update the information of an event

Scenario: The client is able to update the information of an event
Given the client has an edited event
When the client updates the event
Then the returned event contains the new information
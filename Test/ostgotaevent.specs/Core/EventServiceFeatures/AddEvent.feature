Feature: Client should be able to add an event

Scenario: Client wants to add an event to the database
Given the client has created an event
When the user saves the event
Then an event should be returned
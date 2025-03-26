Feature: The client can remove an event

Scenario: The client is able to remove and event by inputting the id for the event
Given the client has the id for event to be removed
When the client removes the event
Then the amount of events goes down
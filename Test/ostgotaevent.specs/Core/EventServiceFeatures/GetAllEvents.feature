Feature: Client can fetch all events

Scenario: the client tries to fetch all current events
Given there exists more than one event in the database
When the client fetches all event
Then it recieves a list with all events
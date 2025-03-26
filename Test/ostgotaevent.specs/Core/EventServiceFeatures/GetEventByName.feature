Feature: Client can fetch an event by searching by the name

Scenario: Client is able to fetch a event by the name
Given the client knows the name to search for
When the client fetches the event by name
Then the client recieves an event
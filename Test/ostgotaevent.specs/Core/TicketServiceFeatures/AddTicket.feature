Feature: Client can add tickets

Scenario: Client can add tickets using the event-id and user-id
Given the client has the user-Id and event-Id
When the client creates a ticket
Then the client is returned a ticket
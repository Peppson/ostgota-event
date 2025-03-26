Feature: Admin can update userdata except password.

Scenario: Admin is able to update userdata
Given the admin has the id for a user
And have updated-userdata
When the admin updates data
Then the new data is saved by the admin
Feature: Get All Users
	
Scenario: Verify status code of getAllUsers
	Given I perform GET operation for "getAllUsers"
	And I execute operation
	Then I should see the "StatusCode" as "200"

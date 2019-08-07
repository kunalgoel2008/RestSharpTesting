Feature: PostAndGet

Scenario: Verify status code of getUsersById and createUser
	Given I perform POST operation for "createUser" with body
	 | id | first_name | last_name | position_id | organisation_id | address_id | mob_no     | alt_mob_no | email   | isDeleted |
	 | 15 | Kunal      | Goel      | 1           | 1               | 1          | 9999123987 | abcdefghij | a@g.com | false     |
	Then I should see the "StatusCode" For POST as "200"
	
	Given I perform GET operation for "getUsers/{id}"
	And I perform operation for ID "15"
	Then I should see the "StatusCode" as "200"
Feature: SkillsTab

As a Project Mars user 
I would be able to insert what Skills I know and level of proficiency
So that the people seeking for skills can know what skills I know and level of proficiency

@order1
@TC_019
Scenario Outline: Verify that a user can successfully add a new skill with a valid name and level.
	Given I logged in successfully
	And I am on my profile page with the skill tab selected
	When I add a new skill with a valid '<SkillName>' and valid '<SkillLevel>'
	Then The '<SkillName>' and the level '<SkillLevel>' should be added to my profile sucessfully

	Examples:

	| SkillName | SkillLevel			|
	| CSharp	| Beginner				|

@order2
@TC_008
Scenario: Verify that the user can remove a skill from the list.
	Given I logged in successfully
	And I am on my profile page with the skill tab selected
	When I add a new skill with a valid '<SkillName>' and valid '<SkillLevel>'
	When I click on the delete button of a skill
	Then the skill should be deleted from my profile

	Examples:

	| SkillName    | SkillLevel			|
	| Selenium	   | Intermediate		|

@order3
@TC_020 
Scenario Outline: Verify that the user can cancel adding a new skill.
	Given I logged in successfully
	And I am on my profile page with the skill tab selected
	When I type a '<SkillName>' and choose a '<SkillLevel>' and I click the cancel button
	Then the skill should not be added to my profile

	Examples:

	| SkillName  	| SkillLevel		|
	| NUnit			| Expert			|

@order4
@TC_021
Scenario Outline: Verify that the user cannot add a skill without selecting a level.
	Given I logged in successfully
	And I am on my profile page with the skill tab selected
	When I type a  '<SkillName>'  and I do not choose a skill level and I click on the add button
	Then an error message should be displayed to the user

	Examples:

	| SkillName  	|
	| Cucumber		|

@order5
@TC_006
Scenario Outline: Verify that the user cannot add a skill without entering the skill name.
	Given I logged in successfully
	And I am on my profile page with the skill tab selected
	When I do not type a SkillName and I choose a '<SkillLevel>'
	Then an error message should be displayed to the user

	Examples:

	| SkillLevel	|
	| Beginner		|

@order6
@TC_023
Scenario Outline: Verify that the user can successfully update a skill level.
	Given I logged in successfully
	And I am on my profile page with the skill tab selected
	When I add a new skill with a valid '<SkillName>' and valid '<SkillLevel>'
	And I click on the update button of a skill
	And I change the skill level to '<NewSkillLevel>'
	Then the skill level should be updated to '<NewSkillLevel>' successfully

	Examples:

	| SkillName    | SkillLevel  		| NewSkillLevel 	|
	| Java	       | Intermediate		| Expert			|

@order7
@TC_25
Scenario Outline: Verify that the user cannot add the same skill twice.
	Given I logged in successfully
	And I am on my profile page with the skill tab selected
	When I add a new skill with a valid '<SkillName>' and valid '<SkillLevel>'
	And I try to add the same '<SkillName>' and same '<SkillLevel>' again
	Then an duplicate skill error message should be displayed

	Examples:

	| SkillName		| SkillLevel	|
	| Python		| Beginner		|
	
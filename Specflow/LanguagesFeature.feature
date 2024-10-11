Feature: LanguagesFeature

As a Project Mars user 
I would be able to insert what languages I know and level of proficiency
So that the people seeking for languages can know what languages I know and level of proficiency

@order1
@TC_003
Scenario Outline: Verify that a user can successfully add a new language with a valid name and level.
	Given I logged in successfully
	And I am on my profile page with the languages tab selected
	When I add a new language with a valid '<LanguageName>' and valid '<LanguageLevel>'
	Then The language '<LanguageName>' and the level '<LanguageLevel>' should be added to my profile sucessfully

	Examples:

	| LanguageName | LanguageLevel		|
	| English      | Basic				|


@order2
@TC_008
Scenario: Verify that the user can delete a language from the list.
	Given I logged in successfully
	And I am on my profile page with the languages tab selected
	When I add a new language with a valid '<LanguageName>' and valid '<LanguageLevel>'
	When I click on the delete button of a language
	Then the language should be deleted from my profile

	Examples:

	| LanguageName | LanguageLevel		|
	| Spanish      | Conversational		|

@order3
@TC_004
Scenario Outline: Verify that the user can cancel adding a new language.
	Given I logged in successfully
	And I am on my profile page with the languages tab selected
	When I type a '<LanguageName>' and choose a '<LanguageLevel>' and I click on the cancel button
	Then the language should not be added to my profile

	Examples:

	| LanguageName	| LanguageLevel		|
	| French		| Fluent			|

@order4
@TC_005
Scenario Outline: Verify that the user cannot add a language without selecting a level.
	Given I logged in successfully
	And I am on my profile page with the languages tab selected
	When I type a '<LanguageName>' and I do not choose a language level and I click on the add button
	Then an error message should be displayed

	Examples:

	| LanguageName	|
	| Japanese		|


@order5
@TC_006
Scenario Outline: Verify that the user cannot add a language without entering the language name.
	Given I logged in successfully
	And I am on my profile page with the languages tab selected
	When I do not type a LanguageName and I choose a '<LanguageLevel>'
	Then an error message should be displayed

	Examples:

	| LanguageLevel	|
	| Fluent		|

@order6
@TC_007
Scenario Outline: Verify that the user can successfully edit a language level.
	Given I logged in successfully
	And I am on my profile page with the languages tab selected
	When I add a new language with a valid '<LanguageName>' and valid '<LanguageLevel>'
	And I click on the edit button of a language
	And I change the language level to '<NewLanguageLevel>'
	Then the language level should be updated to '<NewLanguageLevel>'

	Examples:

	| LanguageName | LanguageLevel		| NewLanguageLevel	|
	| English      | Basic				| Fluent			|

@order7
@TC_009
Scenario Outline: Verify that the user cannot add the same language twice.
	Given I logged in successfully
	And I am on my profile page with the languages tab selected
	When I add a new language with a valid '<LanguageName>' and valid '<LanguageLevel>'
	And I try to add the same '<LanguageName>' and same '<LanguageLevel>'
	Then an duplicate data error message should be displayed

	Examples:

	| LanguageName | LanguageLevel		|
	| English      | Basic				|
 
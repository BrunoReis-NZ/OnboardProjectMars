Feature: LanguagesFeature

As a Project Mars user 
I would be able to insert what languages I know and level of proficiency
So that the people seeking for languages can know what languages I know and level of proficiency

@order1
@TC_003(4)
Scenario Outline: Add a new language to my profile with a valid name and valid level
	Given I logged in successfully
	And I am on my profile page with the languages tab selected
	When I add a new language with a valid '<LanguageName>' and valid '<LanguageLevel>'
	Then The language '<LanguageName>' and the level '<LanguageLevel>' should be added to my profile sucessfully

	Examples:

	| LanguageName | LanguageLevel		|
	| English      | Basic				|
	| Spanish      | Conversational		|
	| French       | Fluent				|
	| German       | Native/Bilingual	|

@order2
@TC_004
Scenario: Verify that the user can delete a language from the list.
	Given I logged in successfully
	And I am on my profile page with the languages tab selected
	When I add a new language with a valid '<LanguageName>' and valid '<LanguageLevel>'
	When I click on the delete button of a language
	Then the language should be deleted from my profile

	Examples:

	| LanguageName | LanguageLevel		|
	| English      | Basic				|

@order2
@TC_005
Scenario Outline: Verify that the user can cancel adding a new language.
	Given I logged in successfully
	And I am on my profile page with the languages tab selected
	When I type a '<LanguageName>' and choose a '<LanguageLevel>' and I click on the cancel button
	Then the language should not be added to my profile

	Examples:

	| LanguageName	| LanguageLevel		|
	| Japanese      | Basic				|



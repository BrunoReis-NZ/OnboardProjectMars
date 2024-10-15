using NUnit.Framework;
using OnboardProjectMars.Pages;
using OnboardProjectMars.TestCases;
using OnboardProjectMars.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace OnboardProjectMars.StepDefinition
{
    [Binding]
    public class SkillsTabStepDefinitions : CommonDriver
    {
        // LoginPage object initialization and definition
        LoginPage loginPageObject = new LoginPage();

        // ProfilePage object initialization and definition
        ProfilePage profilePageObject = new ProfilePage();

        // LanguagesFeature object initialization and definition
        LanguagesTab languagesFeatureObject = new LanguagesTab();

        // SkillsFeature object initialization and definition
        SkillsTab skillsFeatureObject = new SkillsTab();

        [Given(@"I am on my profile page with the skill tab selected")]
        public void GivenIAmOnMyProfilePageWithTheSkillTabSelected()
        {
            // Go to the profile page
            profilePageObject.NavigateToSkillsFeature(driver);
        }

        // TC:019 Verify that a user can successfully add a new skill with a valid name and level.

        [When(@"I add a new skill with a valid '([^']*)' and valid '([^']*)'")]
        public void WhenIAddANewSkillWithAValidNameAndAValidLevel(string skillName, string skillLevel)
        {
            skillsFeatureObject.AddANewSkillWithAValidNameAndLevel(driver, skillName, skillLevel);
        }

        [Then(@"The '([^']*)' and the level '([^']*)' should be added to my profile sucessfully")]
        public void ThenTheSkillNameAndTheSkillLevelShouldBeAddedToMyProfileSucessfully(string skillName, string skillLevel)
        {
            // Get the new Skill and level added to the profile
            string newValidSkill = skillsFeatureObject.GetNewValidSkill(driver, skillName);
            string newValidSkillLevel = skillsFeatureObject.GetNewValidSkillLevel(driver, skillLevel);

            // Verify that the new language and level are added successfully
            Assert.That(newValidSkill == skillName, skillName + " was not added successfully");
            Assert.That(newValidSkillLevel == skillLevel, skillLevel + " was not added successfully");
        }

        // TC:024 Verify that the user can remove a skill from the list.
        // I am using the same step definition for deleting a skill as I used for deleting a language because the steps are the same.
        [When(@"I click on the delete button of a skill")]
        public void WhenIClickOnTheDeleteButtonOfALanguage()
        {
            // Delete all languages
            languagesFeatureObject.DeleteAllLanguagesAndSkills(driver);
        }

        [Then(@"the skill should be deleted from my profile")]
        public void ThenTheSkillShouldBeDeletedFromMyProfile()
        {
            // Verify that the language was deleted from the profile
            int numberOfDeleteButtons = languagesFeatureObject.GetNumberOfDeleteButton(driver);
            Assert.That(numberOfDeleteButtons == 0, "The language was wrongly deleted to the profile");
        }

        // TC:020 Verify that the user can cancel adding a new skill.

        [When(@"I type a '([^']*)' and choose a '([^']*)' and I click the cancel button")]
        public void WhenITypeASkillNameAndChooseASkillLevelAndIClickTheCancelButton(string SkillName, string SkillLevel)
        {
            skillsFeatureObject.CancelAddingANewSkill(driver, SkillName, SkillLevel);
        }

        [Then(@"the skill should not be added to my profile")]
        public void ThenTheSkillShouldNotBeAddedToMyProfile()
        {
            // Verify that the language was deleted from the profile
            int numberOfDeleteButtons = languagesFeatureObject.GetNumberOfDeleteButton(driver);
            Assert.That(numberOfDeleteButtons == 0, "The language was wrongly deleted to the profile");
        }

        // TC:021 Verify that the user cannot add a skill without selecting a level.

        [When(@"I type a  '([^']*)'  and I do not choose a skill level and I click on the add button")]
        public void WhenITypeASkillNameAndIDoNotChooseASkillLevelAndIClickOnTheAddButton(string skillName)
        {
            skillsFeatureObject.AddANewSkillWithoutSelectingALevel(driver, skillName);
        }

        [Then(@"an error message should be displayed to the user")]
        public void ThenAnErrorMessageShouldBeDisplayedToTheUser()
        {
            string errorMessage = skillsFeatureObject.GetErrorMessage(driver);
            Assert.That(errorMessage == "Please enter skill and experience level", "The error message was not displayed");
        }

        // TC:022 Verify that the user cannot add a skill without entering the skill name.

        [When(@"I do not type a SkillName and I choose a '([^']*)'")]
        public void WhenIDoNotTypeASkillNameAndIChooseASkillLevel(string SkillLevel)
        {
            skillsFeatureObject.AddANewSkillWithoutEnteringTheSkillName(driver, SkillLevel);
        }


        // TC:023 Verify that the user can successfully Update a skill level.

        [When(@"I click on the update button of a skill")]
        public void WhenIClickOnTheUpdateButtonOfASkill()
        {
            skillsFeatureObject.UpdateSkillLevel(driver);
        }

        [When(@"I change the skill level to '([^']*)'")]
        public void WhenIChangeTheSkillLevelToNewSkillLevel(string NewSkillLevel)
        {
            skillsFeatureObject.ChangeSkillLevel(driver, NewSkillLevel);
        }

        [Then(@"the skill level should be updated to '([^']*)' successfully")]
        public void ThenTheSkillLevelShouldBeUpdatedToNewSkillLevelSuccessfully(string skillLevel)
        {
            string newSkillLevel = skillsFeatureObject.GetUpdatedSkillLevel(driver, skillLevel);
            Assert.That(newSkillLevel == skillLevel, skillLevel + " was not updated successfully");
        }

        // TC:023 Verify that the user cannot add the same skill twice.
        [When(@"I try to add the same '([^']*)' and same '([^']*)' again")]
        public void WhenITryToAddTheSameSkillNameAndSameSkillLevel(string skillName, string skillLevel)
        {
            skillsFeatureObject.AddTheSameSkillTwice(driver, skillName, skillLevel);
        }

        [Then(@"an duplicate skill error message should be displayed")]
        public void ThenAnDuplicateSkillErrorMessageShouldBeDisplayed()
        {
            string errorMessage = skillsFeatureObject.GetErrorMessageForAddingTheSameLanguageTwice(driver);
            Assert.That(errorMessage == "This skill is already exist in your skill list.", "The error message was not displayed");
        }
    }
}

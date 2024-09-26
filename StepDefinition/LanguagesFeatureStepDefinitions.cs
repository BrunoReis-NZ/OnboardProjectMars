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
    public class LanguagesFeatureStepDefinitions : CommonDriver
    {
        // LoginPage object initialization and definition
        LoginPage loginPageObject = new LoginPage();

        // ProfilePage object initialization and definition
        ProfilePage profilePageObject = new ProfilePage();

        // LanguagesFeature object initialization and definition
        LanguagesTab languagesFeatureObject = new LanguagesTab();


        [Given(@"I logged in successfully")]
        public void GivenILoggedInSuccessfully()
        {
            // Create a new instance of the Chrome driver
            driver = new ChromeDriver();

            // Login to the Mars Portal
            loginPageObject.LoginSteps(driver);

        }

        [Given(@"I am on my profile page with the languages tab selected")]
        public void GivenIAmOnMyProfilePageWithTheLanguagesTabSelected()
        {
            // Go to the profile page
            profilePageObject.NavigateToLanguagesFeature(driver);
        }

        // TC:003 Verify that a user can successfully add a new language with a valid name and level.

        [When(@"I add a new language with a valid '([^']*)' and valid '([^']*)'")]
        public void WhenIAddANewLanguageWithAValidAndValid(string languageName, string languageLevel)
        {
            // add a new language with a valid name and level
            languagesFeatureObject.AddANewLanguageWithAValidNameAndLevel(driver, languageName, languageLevel);
        }

        [Then(@"The language '([^']*)' and the level '([^']*)' should be added to my profile sucessfully")]
        public void ThenTheLanguageAndTheLevelShouldBeAddedToMyProfileSucessfully(string languageName, string languageLevel)
        {
            // Get the new language and level added to the profile
            string newValidLanguage = languagesFeatureObject.GetNewValidLanguage(driver, languageName);
            string newValidLevel = languagesFeatureObject.GetNewValidLevel(driver, languageLevel);

            // Verify that the new language and level are added successfully
            Assert.That(newValidLanguage == languageName, languageName + " was not added successfully");
            Assert.That(newValidLevel == languageLevel, languageLevel + " was not added successfully");
        }
       
        // TC:004 Verify that the user can delete a language from the list.
        [When(@"I click on the delete button of a language")]
        public void WhenIClickOnTheDeleteButtonOfALanguage()
        {
            // Delete all languages
            languagesFeatureObject.DeleteAllLanguages(driver);

        }

        [Then(@"the language should be deleted from my profile")]
        public void ThenTheLanguageShouldBeDeletedFromMyProfile()
        {
            // Verify that the language was deleted from the profile
            int numberOfDeleteButtons = languagesFeatureObject.GetNumberOfDeleteButton(driver);
            Assert.That(numberOfDeleteButtons == 0, "The language was wrongly deleted to the profile");
        }

        // TC:005 Verify that the user can cancel adding a new language.

        [When(@"I type a '([^']*)' and choose a '([^']*)' and I click on the cancel button")]
        public void WhenITypeAAndChooseAAndIClickOnTheCancelButton(string languageName, string languageLevel)
        {
            languagesFeatureObject.CancelAddingANewLanguage(driver, languageName, languageLevel);
        }

        [Then(@"the language should not be added to my profile")]
        public void ThenTheLanguageShouldNotBeAddedToMyProfile()
        {
            int numberOfCancelButtons = languagesFeatureObject.GetNumberOfCancelButton(driver);
            Assert.That(numberOfCancelButtons == 0, "The language was wrongly added to the profile");
        }


        [AfterScenario]
        public void ThenDeleteAllAddedLanguagesAfterTest()
        {
            // Clean up added languages after the scenario
            languagesFeatureObject.DeleteAllLanguages(driver);
            driver.Quit();

        }
               
    }
}

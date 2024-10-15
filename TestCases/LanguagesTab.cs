using NUnit.Framework;
using OnboardProjectMars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnboardProjectMars.TestCases
{
    public class LanguagesTab
    {
        // TC:003 Verify that a user can successfully add a new language with a valid name and level.
        public void AddANewLanguageWithAValidNameAndLevel(IWebDriver driver, string languageName, string languageLevel)
        {
            // Click on Add New
            IWebElement addNew = driver.FindElement(By.XPath("(//div[@class='ui teal button '][contains(.,'Add New')])[1]"));
            addNew.Click();

            // Locate the dropdown element
            IWebElement levelDropDown = driver.FindElement(By.XPath("//select[contains(@class,'ui dropdown')]"));

            // Initialize SelectElement for interacting with the dropdown
            SelectElement selectDropdown = new SelectElement(levelDropDown);

            // Select an option by text
            selectDropdown.SelectByText(languageLevel);

            // Add language
            IWebElement addLanguage = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            addLanguage.SendKeys(languageName);

            // Click on Add
            IWebElement add = driver.FindElement(By.XPath("//input[@value='Add']"));
            add.Click();

        }

        public string GetNewValidLanguage(IWebDriver driver, string languageName)
        {
            // Wait for the new language to be added
            Wait.WaitForElementToBeVisible(driver, "XPath", $"//td[contains(.,'{languageName}')]", 5);

            // Get the new language added to the profile
            IWebElement newValidLanguage = driver.FindElement(By.XPath($"//td[contains(.,'{languageName}')]"));
            return newValidLanguage.Text;
        }

        public string GetNewValidLevel(IWebDriver driver, string languageLevel)
        {
            // Get the new level added to the profile
            IWebElement newValidLevel = driver.FindElement(By.XPath($"//td[contains(.,'{languageLevel}')]"));
            return newValidLevel.Text;        
        }

        // TC:004 Verify that the user can delete a language from the list.

        public void DeleteAllLanguagesAndSkills(IWebDriver driver)
        {
            Thread.Sleep(3000); // I tried to use the Wait class but it didnt work, so I used Thread.Sleep instead

            // Keep looping until no delete buttons are found
            while (driver.FindElements(By.XPath("//i[contains(@class,'remove icon')]")).Count > 0)
            {
                // Find the delete button for the language
                IWebElement deleteButton = driver.FindElement(By.XPath("//i[contains(@class,'remove icon')]"));
                deleteButton.Click();

                // Add a short wait to allow the UI to update after each click
                Thread.Sleep(3000); // I tried to use the Wait class but it didnt work, so I used Thread.Sleep instead
            }
        }

        public int GetNumberOfDeleteButton(IWebDriver driver)
        {
            Thread.Sleep(3000); // I tried to use the Wait class but it didnt work, so I used Thread.Sleep instead

            // Find all elements with the "Delete" button
            var deleteButtons = driver.FindElements(By.XPath("//i[contains(@class,'remove icon')]"));
            Thread.Sleep(3000); // I tried to use the Wait class but it didnt work, so I used Thread.Sleep instead

            // Return the number of elements found
            return deleteButtons.Count;
        }

// TC:004 Verify that a user can successfully cancel adding a new language.
        public void CancelAddingANewLanguage(IWebDriver driver, string languageName, string languageLevel)
        {
            
            // Click on Add New
            IWebElement addNew = driver.FindElement(By.XPath("(//div[@class='ui teal button '][contains(.,'Add New')])[1]"));
            addNew.Click();

            // Locate the dropdown element
            IWebElement levelDropDown = driver.FindElement(By.XPath("//select[contains(@class,'ui dropdown')]"));

            // Initialize SelectElement for interacting with the dropdown
            SelectElement selectDropdown = new SelectElement(levelDropDown);
            
            // Select an option by text
            selectDropdown.SelectByText(languageLevel);
           
            // Add language
            IWebElement addLanguage = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            addLanguage.SendKeys(languageName);
            
            // Click on Cancel
            IWebElement cancel = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            cancel.Click();
        }

        public int GetNumberOfCancelButton(IWebDriver driver)
        {
        // Find all elements with the "Cancel" button
        var cancelButtons = driver.FindElements(By.XPath("//input[@value='Cancel']"));

        // Return the number of elements found
        return cancelButtons.Count;
        }

// TC:005 Verify that the user cannot add a language without selecting a level.

        public void AddANewLanguageWithoutSelectingALevel(IWebDriver driver, string languageName)
        {
            // Click on Add New
            IWebElement addNew = driver.FindElement(By.XPath("(//div[@class='ui teal button '][contains(.,'Add New')])[1]"));
            addNew.Click();

            // Add language
            IWebElement addLanguage = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            addLanguage.SendKeys(languageName);

            // Click on Add
            IWebElement add = driver.FindElement(By.XPath("//input[@value='Add']"));
            add.Click();
        }

        public string GetErrorMessage(IWebDriver driver)
        {
            // Wait for the error message to be displayed
            Wait.WaitForElementToBeVisible(driver, "XPath", "(//div[contains(.,'Please enter language and level')])[2]", 5);

            IWebElement errorMessage = driver.FindElement(By.XPath("(//div[contains(.,'Please enter language and level')])[2]"));
            return errorMessage.Text;
        }

// TC:006 Verify that the user cannot add a language without entering the language name.

        public void AddANewLanguageWithoutEnteringTheLanguageName(IWebDriver driver, string languageLevel)
        {
            // Click on Add New
            IWebElement addNew = driver.FindElement(By.XPath("(//div[@class='ui teal button '][contains(.,'Add New')])[1]"));
            addNew.Click();

            // Locate the dropdown element
            IWebElement levelDropDown = driver.FindElement(By.XPath("//select[contains(@class,'ui dropdown')]"));

            // Initialize SelectElement for interacting with the dropdown
            SelectElement selectDropdown = new SelectElement(levelDropDown);

            // Select an option by text
            selectDropdown.SelectByText(languageLevel);

            // Click on Add
            IWebElement add = driver.FindElement(By.XPath("//input[@value='Add']"));
            add.Click();
        }

// TC:007 Verify that the user can successfully edit a language level.

        public void EditLanguageLevel(IWebDriver driver)
        {
            // Wait for the Edit button to be visible
            Wait.WaitForElementToBeVisible(driver, "XPath", "(//i[contains(@class,'outline write icon')])[2]", 10);

            // Click on Edit
            IWebElement edit = driver.FindElement(By.XPath("(//i[contains(@class,'outline write icon')])[2]"));
            edit.Click();
        }

        public void ChangeLanguageLevel(IWebDriver driver, string NewLanguageLevel)
        {
            // Locate the dropdown element
            IWebElement levelDropDown = driver.FindElement(By.XPath("//select[contains(@class,'ui dropdown')]"));

            // Initialize SelectElement for interacting with the dropdown
            SelectElement selectDropdown = new SelectElement(levelDropDown);

            // Select an option by text
            selectDropdown.SelectByText(NewLanguageLevel);

            // Click on Update
            IWebElement update = driver.FindElement(By.XPath("//input[@value='Update']"));
            update.Click();
        }

        public string GetUpdatedLanguageLevel(IWebDriver driver, string NewLanguageLevel)
        {
            // Wait for the language level to be updated
            Wait.WaitForElementToBeVisible(driver, "XPath", $"//option[contains(text(),'{NewLanguageLevel}')]", 10);

            // Get the updated language level
            IWebElement updatedLanguageLevel = driver.FindElement(By.XPath($"//option[contains(text(),'{NewLanguageLevel}')]"));
            return updatedLanguageLevel.Text;
        }

// TC:009 Verify that the user cannot add the same language twice.

        public void AddTheSameLanguageTwice(IWebDriver driver, string languageName, string languageLevel)
        {
            // Click on Add New
            IWebElement addNew = driver.FindElement(By.XPath("(//div[@class='ui teal button '][contains(.,'Add New')])[1]"));
            addNew.Click();

            // Wait for the Add New Language modal to be visible
            Wait.WaitForElementToBeVisible(driver, "XPath", "//select[contains(@class,'ui dropdown')]", 10);

            // Locate the dropdown element
            IWebElement levelDropDown = driver.FindElement(By.XPath("//select[contains(@class,'ui dropdown')]"));

            // Initialize SelectElement for interacting with the dropdown
            SelectElement selectDropdown = new SelectElement(levelDropDown);

            // Select an option by text
            selectDropdown.SelectByText(languageLevel);

            // Add language
            IWebElement addLanguage = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            addLanguage.SendKeys(languageName);

            // Click on Add
            IWebElement add = driver.FindElement(By.XPath("//input[@value='Add']"));
            add.Click();
        }

        public string GetErrorMessageForAddingTheSameLanguageTwice(IWebDriver driver)
        {
            // Wait for the error message to be displayed
            Wait.WaitForElementToBeVisible(driver, "XPath", "//div[@class='ns-box-inner'][contains(.,'This language is already exist in your language list.')]", 10);

            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner'][contains(.,'This language is already exist in your language list.')]"));
            return errorMessage.Text;
        }

    }
}

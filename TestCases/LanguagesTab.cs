using NUnit.Framework;
using OnboardProjectMars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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


            IWebElement addLanguage = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));

            addLanguage.SendKeys(languageName);

            IWebElement add = driver.FindElement(By.XPath("//input[@value='Add']"));
            add.Click();

        }

        public string GetNewValidLanguage(IWebDriver driver, string languageName)
        {
            // Wait for the new language to be added
            Wait.WaitForElementToBeVisible(driver, "XPath", $"//td[contains(.,'{languageName}')]", 5);

            IWebElement newValidLanguage = driver.FindElement(By.XPath($"//td[contains(.,'{languageName}')]"));
            return newValidLanguage.Text;
        }

        public string GetNewValidLevel(IWebDriver driver, string languageLevel)
        {
            IWebElement newValidLevel = driver.FindElement(By.XPath($"//td[contains(.,'{languageLevel}')]"));
            return newValidLevel.Text;        
        }

// TC:004 Verify that the user can delete a language from the list.

        public void DeleteAllLanguages(IWebDriver driver)
        {
            Thread.Sleep(3000); // Adjust sleep time as needed for your application

            // Keep looping until no delete buttons are found
            while (driver.FindElements(By.XPath("//i[contains(@class,'remove icon')]")).Count > 0)
            {
                // Find the delete button for the language
                IWebElement deleteButton = driver.FindElement(By.XPath("//i[contains(@class,'remove icon')]"));
                deleteButton.Click();

                // Add a short wait to allow the UI to update after each click
                Thread.Sleep(3000); // Adjust sleep time as needed for your application
            }
        }
        public int GetNumberOfDeleteButton(IWebDriver driver)
        {
            Thread.Sleep(3000); // Adjust sleep time as needed for your application

            // Find all elements with the "Delete" button
            var deleteButtons = driver.FindElements(By.XPath("//i[contains(@class,'remove icon')]"));
            Thread.Sleep(3000); // Adjust sleep time as needed for your application

            // Return the number of elements found
            return deleteButtons.Count;
        }

// TC:005 Verify that a user can successfully cancel adding a new language.
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


    }
}

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
    public class SkillsTab
    {

        // TC:019 Verify that a user can successfully add a new skill with a valid name and level.
        public void AddANewSkillWithAValidNameAndLevel(IWebDriver driver, string SkillName, string SkillLevel)
        {
            // Click on Add New
            IWebElement addNew = driver.FindElement(By.XPath("(//div[contains(@class,'ui teal button')])[2]"));
            addNew.Click();

            // Locate the dropdown element
            IWebElement levelDropDown = driver.FindElement(By.XPath("//select[contains(@class,'ui fluid dropdown')]"));

            // Initialize SelectElement for interacting with the dropdown
            SelectElement selectDropdown = new SelectElement(levelDropDown);

            // Select an option by text
            selectDropdown.SelectByText(SkillLevel);

            // Add skill
            IWebElement addSkill = driver.FindElement(By.XPath("//input[contains(@placeholder,'Add Skill')]"));
            addSkill.SendKeys(SkillName);

            // Click on Add
            IWebElement add = driver.FindElement(By.XPath("//input[@value='Add']"));
            add.Click();

        }

        public string GetNewValidSkill(IWebDriver driver, string SkillName)
        {
            // Wait for the new skill to be added
            Wait.WaitForElementToBeVisible(driver, "XPath", $"//td[contains(.,'{SkillName}')]", 5);

            // Get the new skill added to the profile
            IWebElement newValidSkill = driver.FindElement(By.XPath($"//td[contains(.,'{SkillName}')]"));
            return newValidSkill.Text;
        }

        public string GetNewValidSkillLevel(IWebDriver driver, string SkillLevel)
        {
            // Get the new level added to the profile
            IWebElement newValidSkillLevel = driver.FindElement(By.XPath($"//td[contains(.,'{SkillLevel}')]"));
            return newValidSkillLevel.Text;
        }

        // TC:020 Verify that a user can successfully cancel adding a new skill.

        public void CancelAddingANewSkill(IWebDriver driver, string SkillName, string SkillLevel)
        {
            // Click on Add New
            IWebElement addNew = driver.FindElement(By.XPath("(//div[contains(@class,'ui teal button')])[2]"));
            addNew.Click();

            // Locate the dropdown element
            IWebElement levelDropDown = driver.FindElement(By.XPath("//select[contains(@class,'ui fluid dropdown')]"));

            // Initialize SelectElement for interacting with the dropdown
            SelectElement selectDropdown = new SelectElement(levelDropDown);

            // Select an option by text
            selectDropdown.SelectByText(SkillLevel);

            // Add language
            IWebElement addSkill = driver.FindElement(By.XPath("//input[contains(@placeholder,'Add Skill')]"));
            addSkill.SendKeys(SkillName);

            // Click on Cancel
            IWebElement cancel = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            cancel.Click();
        }

        // TC 021 Verify that the user cannot add a skill without selecting a level.

        public void AddANewSkillWithoutSelectingALevel(IWebDriver driver, string SkillName)
        {
            // Click on Add New
            IWebElement addNew = driver.FindElement(By.XPath("//div[@class='ui teal button'][contains(.,'Add New')]"));
            addNew.Click();

            // Add skill
            IWebElement addSkill = driver.FindElement(By.XPath("//input[contains(@placeholder,'Add Skill')]"));
            addSkill.SendKeys(SkillName);

            // Click on Add
            IWebElement add = driver.FindElement(By.XPath("//input[@value='Add']"));
            add.Click();
        }

        public string GetErrorMessage(IWebDriver driver)
        {
            // Wait for the error message to be displayed
            Wait.WaitForElementToBeVisible(driver, "XPath", "(//div[contains(.,'Please enter skill and experience level')])[1]", 5);

            IWebElement errorMessage = driver.FindElement(By.XPath("(//div[contains(.,'Please enter skill and experience level')])[1]"));
            return errorMessage.Text;
        }

        // TC:022 Verify that the user cannot add a skill without entering the skill name.

        public void AddANewSkillWithoutEnteringTheSkillName(IWebDriver driver, string skillLevel)
        {
            // Click on Add New
            IWebElement addNew = driver.FindElement(By.XPath("(//div[contains(@class,'ui teal button')])[2]"));
            addNew.Click();

            // Locate the dropdown element
            IWebElement levelDropDown = driver.FindElement(By.XPath("//select[contains(@class,'ui fluid dropdown')]"));

            // Initialize SelectElement for interacting with the dropdown
            SelectElement selectDropdown = new SelectElement(levelDropDown);

            // Click on Add
            IWebElement add = driver.FindElement(By.XPath("//input[@value='Add']"));
            add.Click();
        }

        // TC:023 Verify that the user can successfully Update a skill level.

        public void UpdateSkillLevel(IWebDriver driver)
        {
            // Wait for the Update button to be visible
            Wait.WaitForElementToBeVisible(driver, "XPath", "(//i[contains(@class,'outline write icon')])[2]", 5);

            // Click on Update button
            IWebElement update = driver.FindElement(By.XPath("(//i[contains(@class,'outline write icon')])[2]"));
            update.Click();
        }

        public void ChangeSkillLevel(IWebDriver driver, string NewSkillLevel)
        {
            // Locate the dropdown element
            IWebElement levelDropDown = driver.FindElement(By.XPath("//select[contains(@name,'level')]"));

            // Initialize SelectElement for interacting with the dropdown
            SelectElement selectDropdown = new SelectElement(levelDropDown);

            // Select an option by text
            selectDropdown.SelectByText(NewSkillLevel);

            // Click on Update
            IWebElement update = driver.FindElement(By.XPath("//input[@value='Update']"));
            update.Click();
        }

        public string GetUpdatedSkillLevel(IWebDriver driver, string NewSkillLevel)
        {
            // Wait for the language level to be updated
            Wait.WaitForElementToBeVisible(driver, "XPath", $"//option[contains(text(),'{NewSkillLevel}')]", 5);

            // Get the updated language level
            IWebElement updatedSkillLevel = driver.FindElement(By.XPath($"//option[contains(text(),'{NewSkillLevel}')]"));
            return updatedSkillLevel.Text;
           
        }

        // TC:025 Verify that the user cannot add the same skill twice.
        public void AddTheSameSkillTwice(IWebDriver driver, string SkillName, string SkillLevel)
        {
            // Click on Add New
            IWebElement addNew = driver.FindElement(By.XPath("(//div[contains(@class,'ui teal button')])[2]"));
            addNew.Click();

            // Wait for the Add New Skill modal to be visible
            Wait.WaitForElementToBeVisible(driver, "XPath", "//select[contains(@class,'ui fluid dropdown')]", 10);

            // Locate the dropdown element
            IWebElement levelDropDown = driver.FindElement(By.XPath("//select[contains(@class,'ui fluid dropdown')]"));

            // Initialize SelectElement for interacting with the dropdown
            SelectElement selectDropdown = new SelectElement(levelDropDown);

            // Select an option by text
            selectDropdown.SelectByText(SkillLevel);

            // Add skill
            IWebElement addSkill = driver.FindElement(By.XPath("//input[contains(@placeholder,'Add Skill')]"));
            addSkill.SendKeys(SkillName);

            // Click on Add
            IWebElement add = driver.FindElement(By.XPath("//input[@value='Add']"));
            add.Click();
        }

        public string GetErrorMessageForAddingTheSameLanguageTwice(IWebDriver driver)
        {
            // Wait for the error message to be displayed
            Wait.WaitForElementToBeVisible(driver, "XPath", "//div[@class='ns-box-inner'][contains(.,'This skill is already exist in your skill list.')]", 10);

            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner'][contains(.,'This skill is already exist in your skill list.')]"));
            return errorMessage.Text;
        }


    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnboardProjectMars.Features
{
    public class LanguagesFeature
    {
        public void AddANewLanguageWithAValidNameAndLevel(IWebDriver driver) 
        {
            // TC:003 Verify that a user can successfully add a new language with a valid name and level.

            // Click on Add New

            IWebElement addNew = driver.FindElement(By.XPath("(//div[@class='ui teal button '][contains(.,'Add New')])[1]"));
            addNew.Click();

            IWebElement addLanguage = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));

            addLanguage.SendKeys("Spanish");

            IWebElement chooseLanguageLevel = driver.FindElement(By.XPath("//select[contains(@class,'ui dropdown')]"));

            chooseLanguageLevel.Click();

            IWebElement languageLevelBasic = driver.FindElement(By.XPath("//option[contains(.,'Basic')]"));
            languageLevelBasic.Click();

            IWebElement add = driver.FindElement(By.XPath("//input[@value='Add']"));
            add.Click();

            Thread.Sleep(5000);


            // Check if the language was added successfully

            IWebElement languageAdded = driver.FindElement(By.XPath("//td[contains(.,'Spanish')]"));
            IWebElement levelAdded = driver.FindElement(By.XPath("//td[contains(.,'Basic')]"));

            if (languageAdded.Text == "Spanish" && levelAdded.Text == "Basic")
            {
                Console.WriteLine("Language added successfully, test passed");
            }
            else
            {
                Console.WriteLine("Language not added, test failed");
            }
        }
    }
}

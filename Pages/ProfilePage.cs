using OnboardProjectMars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardProjectMars.Pages
{
    public class ProfilePage
    {
        public void NavigateToLanguagesFeature(IWebDriver driver)
        {
            // Wait for the page to load
            Wait.WaitForElementToBeVisible(driver, "XPath", "//body/div[@id='account-profile-section']/div[1]/section[1]/div[1]/a[2]", 3);

            // Click on Profile

            IWebElement profile = driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[1]/div[1]/a[2]"));
            profile.Click();

            // Click on Languages

            IWebElement languages = driver.FindElement(By.XPath("//a[@class='item active'][contains(.,'Languages')]"));
            languages.Click();
        }
    }
}

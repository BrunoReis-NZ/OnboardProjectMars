using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OnboardProjectMars.Utilities
{
    public class Wait
    {
        // Generic function to wait for an element to be visible
        public static void WaitForElementToBeVisible(IWebDriver driver, string locatorType, string locatorValue, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));

            if (locatorType =="XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
            }
        }

        // Generic function to wait for an element to be clickable
        public static void WaitForElementToBeClickable(IWebDriver driver, string locatorType, string locatorValue, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));

            if (locatorType == "XPath")
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            }
        }


    }
}

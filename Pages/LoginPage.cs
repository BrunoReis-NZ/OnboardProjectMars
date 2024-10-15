using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardProjectMars.Pages
{
    public class LoginPage
    {
        //Function to login to the Mars Portal

        public void LoginSteps(IWebDriver driver) 
        {
            // Launch the Mars  Website
            driver.Navigate().GoToUrl("http://localhost:5000/");
            // Maximize the browser
            driver.Manage().Window.Maximize();

            // Identify username and password and provide values and click on the login button
            IWebElement signIn = driver.FindElement(By.XPath("//a[contains(text(),'Sign In')]"));
            signIn.Click();

            IWebElement email = driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]"));
            email.SendKeys("brunoreis.nz@gmail.com");

            IWebElement password = driver.FindElement(By.XPath("//input[contains(@name,'password')]"));
            password.SendKeys("ProjectMars8554#");

            IWebElement login = driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/div[1]/div[1]/div[4]/button[1]"));
            login.Click();
        }
    }
}

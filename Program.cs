using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

internal class Program
{
    private static void Main(string[] args)
    {
        // Create a new instance of the Chrome driver
        IWebDriver driver = new ChromeDriver();

        // Launch the Mars  Website
        driver.Navigate().GoToUrl("http://localhost:5000/");
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

        Thread.Sleep(5000);

        // Check if the user is logged in successfully
        IWebElement hiUser = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));

        if (hiUser.Text == "Hi Bruno")
        {
            Console.WriteLine("Logged in successfully, test passed");
        }
        else
        {
            Console.WriteLine("Login failed, test failed");
            
        }

        // Click on Profile
        
        IWebElement profile = driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[1]/div[1]/a[2]"));
        profile.Click();

        // Click on Languages

        IWebElement languages = driver.FindElement(By.XPath("//a[@class='item active'][contains(.,'Languages')]"));
        languages.Click();


        // Tests

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
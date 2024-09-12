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

        IWebElement password = driver.FindElement(By.XPath("//body/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/input[1]"));
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
        

        //IWebElement profile = driver.FindElement(By.XPath("//body/div[@id='account-profile-section']/div[1]/section[1]/div[1]/a[2]"));
        //profile.Click();

        // Click on Languages

        //IWebElement languages = driver.FindElement(By.XPath("//a[@class='item active'][contains(.,'Languages')]"));
        //languages.Click();

        // Click on Add New

        //IWebElement addNew = driver.FindElement(By.XPath("(//div[@class='ui teal button '][contains(.,'Add New')])[1]"));
        //addNew.Click();





    }
}
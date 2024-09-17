using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OnboardProjectMars.Pages;
using OnboardProjectMars.Features;

internal class Program
{
    private static void Main(string[] args)
    {
        // Create a new instance of the Chrome driver
        IWebDriver driver = new ChromeDriver();

        // LoginPage object initialization and definition
        LoginPage loginPageObject = new LoginPage();
        loginPageObject.LoginSteps(driver);

        // ProfilePage object initialization and definition
        ProfilePage profilePageObject = new ProfilePage();
        profilePageObject.NavigateToLanguagesFeature(driver);

        // LanguagesFeature object initialization and definition
        LanguagesFeature languagesFeatureObject = new LanguagesFeature();
        languagesFeatureObject.AddANewLanguageWithAValidNameAndLevel(driver);
    }
}
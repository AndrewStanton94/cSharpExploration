using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V119.HeadlessExperimental;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Tests;

[TestClass]
public class UnitTest1
{
    // [TestMethod]
    // public void TestMethod1()
    // {
    //     Console.WriteLine("The test begins");
    //     Assert.AreEqual(true, true);

    //     // IWebDriver driver = new ChromeDriver();
    //     IWebDriver driver = new FirefoxDriver();

    //     driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

    //     var title = driver.Title;

    //     driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

    //     var textBox = driver.FindElement(By.Name("my-text"));
    //     var submitButton = driver.FindElement(By.TagName("button"));

    //     textBox.SendKeys("Selenium");
    //     submitButton.Click();

    //     var message = driver.FindElement(By.Id("message"));
    //     var value = message.Text;

    //     // driver.Quit();
    // }

    [TestMethod]
    public void TestMethodP()
    {
        // Select browser by commenting out the unwanted driver
        // IWebDriver driver = new ChromeDriver();
        IWebDriver driver = new FirefoxDriver();

        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

        // Start at the homepage
        driver.Navigate().GoToUrl("https://www.port.ac.uk");

        // Is the title as expected?
        var title = driver.Title;
        Assert.AreEqual("University of Portsmouth | A New Breed of University", title);
        Console.WriteLine($"The title is {title}");

        // Find and open the searchbar in the top nav (desktop version)
        var showSearchButton = driver.FindElement(By.ClassName("header__search"));
        showSearchButton.Click();

        var topNavSearchBox = driver.FindElement(By.Id("autocomplete-0-input"));
        Console.WriteLine($"Displayed: {topNavSearchBox.Displayed}");

        // Perform search
        topNavSearchBox.SendKeys("jim briggs");
        topNavSearchBox.Submit();

        // Check search results
        var searchCount = driver.FindElement(By.ClassName("search__count"));
        bool hasResults = searchCount.Text.Contains("results found");
        Assert.IsTrue(hasResults);
        Console.WriteLine($"Search count: {searchCount.Text}");

        // Open Jim's profile
        driver.FindElement(By.ClassName("people-profile")).Click();
        // Need to make it wait to prevent it testing on the old page
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        wait.Until(d => driver.Title == "Jim Briggs | University of Portsmouth");
        Assert.AreEqual("https://www.port.ac.uk/about-us/structure-and-governance/our-people/our-staff/jim-briggs", driver.Url);

        // This doesn't seem to work
        Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
        screenshot.SaveAsFile("./screenshot.png"); // Format values are Bmp, Gif, Jpeg, Png, Tiff

        // driver.Quit();
    }
}
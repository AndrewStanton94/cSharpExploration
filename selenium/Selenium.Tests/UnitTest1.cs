using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Selenium.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Console.WriteLine("The test begins");
        Assert.AreEqual(true, true);

        // IWebDriver driver = new ChromeDriver();
        IWebDriver driver = new FirefoxDriver();

        driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

        var title = driver.Title;

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

        var textBox = driver.FindElement(By.Name("my-text"));
        var submitButton = driver.FindElement(By.TagName("button"));

        textBox.SendKeys("Selenium");
        submitButton.Click();

        var message = driver.FindElement(By.Id("message"));
        var value = message.Text;

        // driver.Quit();
    }
}
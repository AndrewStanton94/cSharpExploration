namespace Selenium.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Console.WriteLine("The test begins");
        Assert.AreEqual(true, true);
    }
}
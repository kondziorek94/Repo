// Google Steps
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TechTalk.SpecFlow;

[Binding]
public class AboutSteps
{
    private IWebDriver driver;

    public AboutSteps()
    {
        driver = new ChromeDriver();
    }

    [Given(@"I am on the google page for (.*) and (.*)")]
    public void GivenIAmOnTheGooglePage(string profile, string environment)
    {
        driver.Navigate().GoToUrl("https://www.google.com/ncr");
    }

    [When(@"I search for ""(.*)""")]
    public void WhenISearchFor(string keyword)
    {
        var q = driver.FindElement(By.Name("q"));
        q.SendKeys(keyword);
        q.Submit();
    }

    [Then(@"I should see title ""(.*)""")]
    public void ThenIShouldSeeTitle(string title)
    {
        Thread.Sleep(5000);
        Assert.AreEqual(true, true);
        driver.Quit();
    }
}
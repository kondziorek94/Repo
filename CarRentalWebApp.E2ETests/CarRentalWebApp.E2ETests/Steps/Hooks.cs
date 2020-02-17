using CarRentalWebApp.E2ETests.Models;
using OpenQA.Selenium;
using System.IO;
using TechTalk.SpecFlow;
using VideoCapturing;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Gherkin.Model;
using CarRentalWebApp.E2ETests.Features;
using AventStack.ExtentReports.Gherkin.Model;


namespace CarRentalWebApp.E2ETests.Steps
{
    [Binding]
    public class Hooks
    {
        private IWebDriver driver;
        private static ExtentReports extentReports;
        private static ExtentTest extentFeature, extentScenario;
        public Recorder Recorder { get; set; }
        private static string videoDirectory = System.Configuration.ConfigurationManager.AppSettings["VideoDirectory"];
        private static string currentRecordingTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            int a = 4, b = 7;
            string s = $"{a} al było na sali, a psów aż {b}";//string interpolation
            string s1 = a + "al było na sali, a psów aż " + b;

            String reportPath = $@"D:\Repo\CarRentalWebApp.E2ETests\TestExtendedReports\Chrome{currentRecordingTime}\";
            System.IO.Directory.CreateDirectory(reportPath);
            var extentHtmlReporter = new ExtentHtmlReporter(reportPath);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
            //Gdzie nalezy umiescic powyzsze 3 linijki?
            //Skad wziac:
            //-tytul feature
            //-tytul testu
            //-nazwe kroku
            //-typ kroku
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extentReports.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            extentFeature = extentReports.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);//"opis feature");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            extentScenario = extentFeature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            WebDriverInstance.Reinstiate();
            driver = WebDriverInstance.INSTANCE;
            // driver.Manage().Window.FullScreen();
            driver.Manage().Window.Maximize();
            Recorder = new Recorder(new RecorderParams(getVideoRecordingPath(), 15, SharpAvi.KnownFourCCs.Codecs.Xvid, 70));
        }

        [AfterStep]
        public void AfterStep()
        {
            // 1. Sparametryzuj metode Create Node wlasciwym typem kroku
            var stepType = ScenarioContext.Current.StepContext.StepInfo.StepDefinitionType.ToString();

            var step = extentScenario.CreateNode(stepType, ScenarioContext.Current.StepContext.StepInfo.Text);//skad wziac typ kroku?
                                                                                                              // obiektzwroconyw65linijkce.Fail(""/* stos wywolan np. itp. message */);
            if (ScenarioContext.Current.TestError != null)
            {
                step.Fail(ScenarioContext.Current.TestError.Message);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Dispose();
            Recorder?.Dispose();
            if (ScenarioContext.Current.TestError == null)
            {
                File.Delete(getVideoRecordingPath());
            }
        }

        public string getVideoRecordingPath()
        {
            var videoRecordingsPath = videoDirectory + "/" + currentRecordingTime;
            if (!Directory.Exists(videoRecordingsPath))
            {
                Directory.CreateDirectory(videoRecordingsPath);

            }
            string filePath = videoRecordingsPath + "/" + ScenarioContext.Current.ScenarioInfo.Title + ".avi";
            return filePath;
        }
    }
}
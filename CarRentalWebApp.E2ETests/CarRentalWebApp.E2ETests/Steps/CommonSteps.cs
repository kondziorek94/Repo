using CarRentalWebApp.E2ETests.Models;
using OpenQA.Selenium;
using System.IO;
using TechTalk.SpecFlow;
using VideoCapturing;
using System;

namespace CarRentalWebApp.E2ETests.Steps
{
    [Binding]
    public class CommonSteps
    {
        private IWebDriver driver;
        public Recorder Recorder { get; set; }
        private static string videoDirectory = System.Configuration.ConfigurationManager.AppSettings["VideoDirectory"];
        private static string currentRecordingTime = DateTime.Now.ToString("ddMMyyyy hhmmss");
        [Before]
        public void BeforeScenario()
        {
            WebDriverInstance.Reinstiate();
            driver = WebDriverInstance.INSTANCE;
            var videoRecordingsPath = videoDirectory + "/" + currentRecordingTime;
            if (!Directory.Exists(videoRecordingsPath))
            {
                Directory.CreateDirectory(videoRecordingsPath);

            }
            string filePath = videoRecordingsPath + "/" + ScenarioContext.Current.ScenarioInfo.Title + ".avi";
            Recorder = new Recorder(new RecorderParams(filePath, 15, SharpAvi.KnownFourCCs.Codecs.Xvid, 70));
        }

        [After]
        public void AfterScenario()
        {
            driver.Dispose();
            Recorder?.Dispose();
        }
    }
}
    //1. sprawic zeby zachowane byly tylko nagrania testow ktore sfailowaly
    //2. sprawic by przegladarka otwierala sie w trybie pelnoekranowym
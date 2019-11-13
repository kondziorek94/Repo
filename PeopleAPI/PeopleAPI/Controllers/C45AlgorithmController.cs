using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PeopleAPI.Models;

namespace PeopleAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class C45AlgorithmController : ControllerBase
    {
        private static readonly int[] days = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        private static readonly String[] outlook = new String[] { "Sunny", "Sunny", "Overcast", "Rain", "Rain", "Rain", "Overcast", "Sunny", "Sunny", "Rain", "Sunny", "Overcast", "Overcast", "Rain" };
        private static readonly int[] temperatures = new int[] { 85, 80, 83, 70, 68, 65, 64, 72, 69, 75, 75, 72, 81, 71 };
        private static readonly int[] humidity = new int[] { 85, 90, 78, 96, 80, 70, 65, 95, 70, 80, 70, 90, 75, 80 };
        private static readonly String[] wind = new String[] { "Weak", "Strong", "Weak", "Weak", "Weak", "Strong", "Strong", "Weak", "Weak", "Weak", "Strong", "Strong", "Weak", "Strong" };
        private static readonly String[] decision = new String[] { "No", "No", "Yes", "Yes", "Yes", "No", "Yes", "No", "Yes", "Yes", "Yes", "Yes", "Yes", "No" };

        static C45AlgorithmController()
        {
            for (int i = 0; i < days.Length; i++)
            {
                new WeatherReport(days[i], outlook[i], temperatures[i], humidity[i], wind[i], decision[i]);
            }
        }

        public static double CalculateGlobalEntropy()
        {
            int yesCount = 0;
            int noCount = 0;
            foreach (var day in WeatherReport.WeatherReports)
            {
                if (day.Decision.Equals("Yes"))
                    yesCount++;
                else if (day.Decision.Equals("No"))
                    noCount++;
            }
            return CalculateEntropy(noCount, yesCount, WeatherReport.WeatherReports.Count());
        }

        public double WindGainRatio()
        {
            double weakWindEntropy;
            double strongWindEntropy;
            double gain;
            double splitInfo;
            int yesCounterWeakWind = 0;
            int noCounterWeakWind = 0;
            int yesCounterStrongWind = 0;
            int noCounterStrongWind = 0;
            int strongWindCounter;
            int weakWindCounter;


            foreach (var day in WeatherReport.WeatherReports)
            {
                if (day.Decision.Equals("Yes") && day.Wind.Equals("Weak"))
                {
                    yesCounterWeakWind++;
                }
                else if (day.Decision.Equals("No") && day.Wind.Equals("Weak"))
                {
                    noCounterWeakWind++;
                }
                else if (day.Decision.Equals("Yes") && day.Wind.Equals("Strong"))
                {
                    yesCounterStrongWind++;
                }
                else
                {
                    noCounterStrongWind++;
                }
            }

            strongWindCounter = yesCounterStrongWind + noCounterStrongWind;
            weakWindCounter = noCounterWeakWind + yesCounterWeakWind;
            weakWindEntropy = CalculateEntropy(yesCounterWeakWind, noCounterWeakWind, weakWindCounter);
            strongWindEntropy = CalculateEntropy(yesCounterStrongWind, noCounterStrongWind, strongWindCounter);
            gain = CalculateGlobalEntropy() - (weakWindCounter / WeatherReport.WeatherReports.Count) * weakWindEntropy - (strongWindCounter / WeatherReport.WeatherReports.Count) * strongWindEntropy;
            splitInfo = CalculateWindSplitInfo(weakWindCounter, strongWindCounter);
            return gain / splitInfo;
        }

        private static double CalculateWindSplitInfo(int weakWindCounter, int strongWindCounter)
        {
            if (weakWindCounter == 0)
                return (-1) * (strongWindCounter / WeatherReport.WeatherReports.Count) * Math.Log2(strongWindCounter / WeatherReport.WeatherReports.Count);
            else if (strongWindCounter == 0)
                return (-1) * (weakWindCounter / WeatherReport.WeatherReports.Count) * Math.Log2(weakWindCounter / WeatherReport.WeatherReports.Count);
            else if (weakWindCounter == 0 && strongWindCounter == 0)
                return 0;
            return (-1) * (weakWindCounter / WeatherReport.WeatherReports.Count) * Math.Log2(weakWindCounter / WeatherReport.WeatherReports.Count) - (strongWindCounter / WeatherReport.WeatherReports.Count * Math.Log2(strongWindCounter / WeatherReport.WeatherReports.Count));
        }

        public double OutlookGainRatio()
        {
            double sunnyEntropy;
            double overcastEntropy;
            double rainEntropy;
            double gain;
            double splitInfo;
            int sunnyYesCounter = 0;
            int sunnyNoCounter = 0;
            int overcastYesCounter = 0;
            int overcastNoCounter = 0;
            int rainyYesCounter = 0;
            int rainyNoCounter = 0;
            int sunnyCounter;
            int overCastCounter;
            int rainyCounter;

            foreach (var day in WeatherReport.WeatherReports)
            {
                if (day.Decision.Equals("Yes") && day.Outlook.Equals("Sunny"))
                {
                    sunnyYesCounter++;
                }
                else if (day.Decision.Equals("No") && day.Outlook.Equals("Sunny"))
                {
                    sunnyNoCounter++;
                }
                else if (day.Decision.Equals("Yes") && day.Outlook.Equals("Overcast"))
                {
                    overcastYesCounter++;
                }
                else if (day.Decision.Equals("No") && day.Outlook.Equals("Overcast"))
                {
                    overcastNoCounter++;
                }
                else if (day.Decision.Equals("Yes") && day.Outlook.Equals("Rainy"))
                {
                    rainyYesCounter++;
                }
                else
                {
                    rainyNoCounter++;
                }
            }
            sunnyCounter = sunnyYesCounter + sunnyNoCounter;
            overCastCounter = overcastYesCounter + overcastNoCounter;
            rainyCounter = rainyYesCounter + rainyNoCounter;
            sunnyEntropy = CalculateEntropy(sunnyYesCounter, sunnyNoCounter, sunnyCounter);
            overcastEntropy = CalculateEntropy(overcastNoCounter, overcastYesCounter, overCastCounter);
            rainEntropy = CalculateEntropy(rainyNoCounter, rainyYesCounter, rainyCounter);
            gain = CalculateGlobalEntropy() - (sunnyEntropy * sunnyCounter / WeatherReport.WeatherReports.Count) - (overcastEntropy * overCastCounter / WeatherReport.WeatherReports.Count) - (rainEntropy * rainyCounter / WeatherReport.WeatherReports.Count);
            splitInfo = (-1) * (sunnyCounter / WeatherReport.WeatherReports.Count) * Math.Log2(sunnyCounter / WeatherReport.WeatherReports.Count) - (overCastCounter / WeatherReport.WeatherReports.Count) * Math.Log2(overCastCounter / WeatherReport.WeatherReports.Count) - (rainyCounter / WeatherReport.WeatherReports.Count) * Math.Log2(rainyCounter / WeatherReport.WeatherReports.Count);
            return gain / splitInfo;
        }

        private static double CalculateEntropy(int noCounter, int yesCounter, int counter)
        {
            if (noCounter == 0)
                return (-1) * (yesCounter / counter) * Math.Log2(yesCounter / counter);
            else if (yesCounter == 0)
                return (-1) * (noCounter / counter) * Math.Log2(noCounter / counter);
            else if (yesCounter == 0 && noCounter == 0)
                return 0;
            return (-1) * (noCounter / counter) * Math.Log2(noCounter / counter) - (yesCounter / counter) * Math.Log2(yesCounter / counter);
        }

        public void HumidityAttribute()
        {
            WeatherReport.WeatherReports.Sort((data1, data2) => data1.Humidity.CompareTo(data2.Humidity));
            List<double> thresholdForHumidityData = new List<double>();
        }

        public double CheckThresholdForHumidity(int humidity, List<WeatherForecast> weathers)
        {
            return 0d;
        }
    }
}
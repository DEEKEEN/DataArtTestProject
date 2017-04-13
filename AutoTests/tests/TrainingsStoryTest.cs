using System;
using NUnit.Framework;
using AutoFramework;
using OpenQA.Selenium;
using AutoFramework.steps;
using AutoFramework.Manager;
using System.Collections.Generic;

namespace AutoTests.tests
{
    
    [TestFixture("Chrome", "55.0", "Windows 8")]
    [Parallelizable(ParallelScope.Self)]
    [Category("Trainings and Knowledge Tests")]
    public class TrainingsStoryTest : WebBaseStoryTest
    {
        private TrainingsSteps trainingsSteps;

        public TrainingsStoryTest(string browser, string version, string platform)
            : base(browser, version, platform)
        {
        }

        public TrainingsStoryTest(string browser, string version, string platform, string deviceName,
             string deviceOrientation)
             : base(browser, version, platform, extraSauceLabsOptions: new Dictionary<string, object>()
             {
                { nameof(deviceName), deviceName },
                { nameof(deviceOrientation), deviceOrientation },
                { "autoAcceptAlerts", true },
                { "waitForAppScript", true },
                { "idleTimeout", 20 }
             })
        {
        }

        [Test]
        public void aaa()
        {
            trainingsSteps = FeatureManager.GetFeature<TrainingsSteps>();
            //trainingsSteps.NavigateToUrl("https://www.google.com.ua");

            trainingsSteps.NavigateToUrl("https://danfoss-devi-umbraco-uat.azurewebsites.net/en/trainings/");

            trainingsSteps.WaitForPageToLoad();

            trainingsSteps.IsLanguageFlagDisplayed();

            trainingsSteps.IsHeroImageDisplayed();

            trainingsSteps.ClickOnButton("Documentation");

        }
    }
}
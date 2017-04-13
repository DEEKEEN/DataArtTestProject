using NUnit.Framework;
using AutoFramework.Manager;
using AutoFramework.pages;
using System;
using AutoFramework.components;

namespace AutoFramework.steps
{
    public class TrainingsSteps
    {
        private TrainingsPage trainingsPage;
        
        public TrainingsSteps()
        {
            trainingsPage = PageManager.GetPage<TrainingsPage>();
        }

        public HeaderSectionPanel GetHeaderPanel()
        {
            return new HeaderSectionPanel();
        }

        public void NavigateToUrl(string url)
        {
            trainingsPage.NavigateToUrl(url);
        }

        public void WaitForPageToLoad()
        {
            trainingsPage.WaitForPageToLoad();
        }

        public void IsHeroImageDisplayed()
        {
            Assert.IsTrue(trainingsPage.IsHeroImageDisplayed(), "Trainings Hero image is not displayed");
        }

        public void ClickOnButton(string buttonName)
        {
            trainingsPage.ClickOnButton(buttonName);
        }

        public void IsLanguageFlagDisplayed()
        {
            Assert.IsTrue(trainingsPage.GetHeaderPanel().IsLanguageFlagDisplayed(), "Trainings Hero image is not displayed");
        }
    }
}

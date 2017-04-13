using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using AutoFramework.components;

namespace AutoFramework.pages
{
    public class TrainingsPage : WebBasePage
    {
        public HeaderSectionPanel GetHeaderPanel()
        {
            return new HeaderSectionPanel();
        }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'hero-image__image')]")]
        private IWebElement _heroImage;

        public void NavigateToUrl(string url)
        {
            WebBaseStoryTest.Driver.Navigate().GoToUrl(url);
        }

        public bool IsHeroImageDisplayed()
        {
            return _heroImage.Displayed;
        }

        public void ClickOnButton(string buttonName)
        {
           webDriver.FindElement(By.XPath(string.Format("//span[contains(text(),'{0}')]/parent::a", buttonName))).Click();
        }

        public bool IsStepItemActive(string title)
        {
            return webDriver.FindElement(By.XPath(string.Format("//div[@class='info-steps-wrap']/div[contains(@class,'active') and contains(text(),'{0}')]", title))).Displayed;
        }
    }
}

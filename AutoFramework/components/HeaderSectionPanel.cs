using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoFramework.components
{
    public class HeaderSectionPanel : WebBasePage
    {
        private IWebElement headerPanel;

        [FindsBy(How = How.XPath, Using = "//div[@class='toggle-area']/span")]
        public IWebElement _languageFlag;

        public void expandLanguageDropdown()
        {
            IWebElement element = headerPanel.FindElement(By.XPath("//button[contains(@class,'language-selector__active')]"));
            element.Click();
        }

        public void changeLanguageInto(String language)
        {
            String xPath = String.Format("//a[@class='language-selector__link' and contains(text(),'Japanese')]", language);
            IWebElement element = headerPanel.FindElement(By.XPath(xPath));
            element.Click();
        }

        public void clickOnDaikinHeaderLogo()
        {
            IWebElement element = headerPanel.FindElement(By.XPath("//img[@class='header__logo']"));
            element.Click();
        }

        public bool IsLanguageFlagDisplayed()
        {
            return _languageFlag.Displayed;
        }
    }
}

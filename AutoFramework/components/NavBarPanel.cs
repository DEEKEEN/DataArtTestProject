using System;
using OpenQA.Selenium;

namespace AutoFramework.components
{
    public class NavBarPanel : WebBasePage
    {

        private IWebElement navBarPanel;

        public void clickOnNavBarItem(String items)
        {
            String xPath = String.Format("//a[@class = 'main-nav__link' and contains(text(),'{0}')]", items);
            IWebElement element = navBarPanel.FindElement(By.XPath(xPath));
            element.Click();
        }
    }
}

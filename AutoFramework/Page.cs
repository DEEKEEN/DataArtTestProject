using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoFramework
{
    public abstract class Page
    {
        protected IWebDriver webDriver;

        public abstract string Url { get; }

        public Page()
        {
            this.webDriver = WebBaseStoryTest.Driver;
            PageFactory.InitElements((ISearchContext)webDriver, (object)this);
        }

        public void Navigate()
        {
            this.webDriver.Navigate().GoToUrl(this.Url);
        }
    }
}

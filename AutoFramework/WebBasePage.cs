using AutoFramework.components;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AutoFramework
{
    public class WebBasePage : Page
    {

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'header__top')]/div[contains(@class,'container')]")]
        private IWebElement headerPanel;

        [FindsBy(How = How.XPath, Using = "//div[@class='header__bottom print-off']")]
        private IWebElement navBarPanel;

        public override string Url
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public HeaderSectionPanel getHeaderSection()
        {
            return new HeaderSectionPanel();
        }

        public NavBarPanel getNavBarPanel()
        {
            return new NavBarPanel();
        }

        public String GetFullUrl()
        {
            string url = this.webDriver.Url;
           
            return url;
        }

        public void WaitForPageToLoad()
        {
            var timeout = new TimeSpan(0, 0, 5);
            var wait = new WebDriverWait(this.webDriver, timeout);

            var javascript = this.webDriver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("driver", "Driver must support javascript execution");

            wait.Until((d) =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript(
                        "if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    //Window is no longer available
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });

        }
        public void waitForElementToBeClickable(IWebElement element)
        {
            var wait = new WebDriverWait(this.webDriver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
    }
}

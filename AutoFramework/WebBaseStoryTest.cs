using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AutoFramework
{

    [TestFixture]
    public class WebBaseStoryTest : IBaseStory
    {
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        private String browser;
        private String version;
        private String platform;
        private IDictionary<string, object> extraSauceLabsOptions;
        protected IWebDriver webDriver;

        public WebBaseStoryTest(String browser, String version, String platform)
        {
            this.browser = browser;
            this.version = version;
            this.platform = platform;
        }

        public WebBaseStoryTest()
        { }

        public WebBaseStoryTest(string browser, string version, string platform, IDictionary<string, object> extraSauceLabsOptions = null)
        : this(browser, version, platform)
        {
            this.extraSauceLabsOptions = extraSauceLabsOptions;
        }

        [SetUp]
        public void Initialize()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName, browser);
            caps.SetCapability(CapabilityType.Version, version);
            caps.SetCapability(CapabilityType.Platform, platform);
            foreach (KeyValuePair<string, object> keyValuePair in (IEnumerable<KeyValuePair<string, object>>)(this.extraSauceLabsOptions ?? (IDictionary<string, object>)new Dictionary<string, object>()))
                caps.SetCapability(keyValuePair.Key, keyValuePair.Value);
            caps.SetCapability("idle-timeout", 180);
            caps.SetCapability("username", "Maverick23");
            caps.SetCapability("accessKey", "74915521-e103-4d2c-b1e6-66047a87df6b");
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);

            driver.Value = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps, TimeSpan.FromSeconds(180));
            driver.Value.Manage().Window.Maximize();
        }

        [TearDown]
        public static void TestFixtureTearDown()
        {
            bool passed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
            try
            {
                ((IJavaScriptExecutor)driver.Value).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            }
            finally
            {
                driver.Value.Quit();
            }
        }

        public static IWebDriver Driver
        {
            get { return driver.Value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFramework
{
    public static class Constants
    {
        internal static string sauceUser = Environment.GetEnvironmentVariable("G1a4");
        internal static string sauceKey = Environment.GetEnvironmentVariable("ab871866-18c9-4083-bf20-acd4320d9889");
        internal static string sauceUri = Environment.GetEnvironmentVariable("http://ondemand.saucelabs.com:80/wd/hub");
        internal static string appStartPage = Environment.GetEnvironmentVariable("http://danfoss-dsd-umbraco-integration.azurewebsites.net/en/");
    }
}

using OpenQA.Selenium.Support.PageObjects;
namespace AutoFramework.Manager
{
    public static class PageManager
    {
        public static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(WebBaseStoryTest.Driver, page);
            return page;
        }
    }
}

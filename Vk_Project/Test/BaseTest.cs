using Aquality.Selenium.Browsers;
using NUnit.Framework;
using Vk_Project.Utils;

namespace Vk_Project.Test
{
    public class BaseTest
    {
        [SetUp]
        public void BeforeTest()
        {
            AqualityServices.Browser.GoTo(Configurator.GetConfig()["Url"]);
            AqualityServices.Browser.Maximize();
        }

        [TearDown]
        public void AfterTest()
        {
            AqualityServices.Browser.Quit();
        }
    }
}
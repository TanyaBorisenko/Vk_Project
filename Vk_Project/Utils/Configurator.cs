using Microsoft.Extensions.Configuration;

namespace Vk_Project.Utils
{
    public static class Configurator
    {
        private static readonly ConfigurationBuilder Config;
        private static readonly ConfigurationBuilder TestData;

        static Configurator()
        {
            Config = new ConfigurationBuilder();
            TestData = new ConfigurationBuilder();
        }

        public static IConfiguration GetConfig()
        {
            Config.AddJsonFile("Resources/configSettings.json", true, true);
            var config = Config.Build();

            return config;
        }

        public static IConfiguration GetTestDataSettings()
        {
            TestData.AddJsonFile("Resources/testDataSettings.json", true, true);
            var config = TestData.Build();

            return config;
        }
    }
}
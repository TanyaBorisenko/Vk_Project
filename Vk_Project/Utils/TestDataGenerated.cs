using Bogus;

namespace Vk_Project.Utils
{
    public static class TestDataGenerated
    {
        private static Faker Faker => new();

        public static string GenerateSomeText()
        {
            return Faker.Random.Word();
        }
    }
}
using SteamStorefrontAPI;
using SteamStorefrontAPI.Classes;

namespace Tests
{
    public class UnitTests
    {
        public class AppDetailsTestObject
        {
            public int AppId { get; set; }
            public string Name { get; set; }
            public string AdditionalProperty1 { get; set; }
        }

        public static IEnumerable<object[]> AppDetailsData()
        {
            yield return new object[] { new AppDetailsTestObject { AppId = 550, Name = "Left 4 Dead 2", AdditionalProperty1 = "Value1" } };
            yield return new object[] { new AppDetailsTestObject { AppId = 620, Name = "Portal 2", AdditionalProperty1 = "Value2" } };
            yield return new object[] { new AppDetailsTestObject { AppId = 546560, Name = "Half-Life: Alyx", AdditionalProperty1 = "Value2" } };
        }

        [Theory]
        [MemberData(nameof(AppDetailsData))]
        public async Task GetAppDetails(AppDetailsTestObject testData)
        {
            SteamApp appDetails = await AppDetails.GetAsync(testData.AppId);
            Assert.Equal(testData.AppId, appDetails.SteamAppId);
            Assert.Equal(testData.Name, appDetails.Name);
        }
    }
}
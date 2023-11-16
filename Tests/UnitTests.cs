using SteamStorefrontAPI;
using SteamStorefrontAPI.Classes;

namespace Tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData(550)]
        [InlineData(620)]
        public async Task GetAppDetails(int appId)
        {
            SteamApp appDetails = await AppDetails.GetAsync(appId);
            Assert.Equal(appId, appDetails.SteamAppId);
        }
    }
}
using SteamStorefrontAPI;
using SteamStorefrontAPI.Classes;

namespace Tests
{
    public class UnitTests
    {
        public static IEnumerable<object[]> AppDetailsData =>
            new List<object[]>
            {
                new object[] { 550, "Left 4 Dead 2"},
                new object[] { 620, "Portal 2"},
                new object[] { 546560, "Half-Life: Alyx"},
            };

        [Theory]
        [MemberData(nameof(AppDetailsData))]
        public async Task GetAppDetails(int appId, string name)
        {
            SteamApp appDetails = await AppDetails.GetAsync(appId);
            Assert.Equal(appId, appDetails.SteamAppId);
            Assert.Equal(name, appDetails.Name);
        }

        public static IEnumerable<object[]> AppDetailsRegionData =>
            new List<object[]>
            {
                new object[] { 546560, "Half-Life: Alyx", "US", "USD" },
                new object[] { 546560, "Half-Life: Alyx", "DE", "EUR" },
                new object[] { 546560, "Half-Life: Alyx", "JP", "JPY" },
            };

        [Theory]
        [MemberData(nameof(AppDetailsRegionData))]
        public async Task GetAppRegionDetails(int appId, string name, string region, string currency)
        {
            SteamApp appDetails = await AppDetails.GetAsync(appId, region);
            Assert.Equal(appId, appDetails.SteamAppId);
            Assert.Equal(name, appDetails.Name);
            Assert.Equal(currency, appDetails.PriceOverview.Currency);
        }


        public static IEnumerable<object[]> AppDetailsLocalizationData =>
            new List<object[]>
            {
                new object[] { 546560, "Half-Life: Alyx", "US", "english", "adventure" },
                new object[] { 546560, "Half-Life: Alyx", "US", "german", "abenteuer" },
                new object[] { 546560, "Half-Life: Alyx", "US", "japanese", "アドベンチャー" },
            };

        [Theory]
        [MemberData(nameof(AppDetailsLocalizationData))]
        public async Task GetAppLocalizationDetails(int appId, string name, string region, string language, string localizedGenre)
        {
            SteamApp appDetails = await AppDetails.GetAsync(appId, region, language);
            Assert.Equal(appId, appDetails.SteamAppId);
            Assert.Equal(name, appDetails.Name);
            Assert.Contains(appDetails.Genres, genre => genre.Description.ToLower() == localizedGenre);
        }

        public static IEnumerable<object[]> PackageDetailsData =>
            new List<object[]>
            {
                new object[] { 134870, "Half-Life: Alyx", 546560 },
                new object[] { 438274, "Half-Life: Alyx - Commercial License", 546560 },
                new object[] { 204528, "Portal 2 - Commercial License", 620 },
                new object[] { 7877, "Portal 2", 620 },
                new object[] { 220726, "Left 4 Dead 2 - Commercial License",550 },
            };

        [Theory]
        [MemberData(nameof(PackageDetailsData))]
        public async Task GetPackageDetails(int packageId, string name, int application)
        {
            PackageInfo packageInfo = await PackageDetails.GetAsync(packageId);
            Assert.Equal(packageId, packageInfo.SteamPackageId);
            Assert.Equal(name, packageInfo.Name);
            Assert.Contains(packageInfo.Apps, app => app.Id == application);
        }

        public static IEnumerable<object[]> PackageDetailsRegionData =>
            new List<object[]>
            {
                new object[] { 134870, "Half-Life: Alyx", "US", "USD" },
                new object[] { 134870, "Half-Life: Alyx", "DE", "EUR" },
                new object[] { 134870, "Half-Life: Alyx", "JP", "JPY" },
            };

        [Theory]
        [MemberData(nameof(PackageDetailsRegionData))]
        public async Task GetPackageRegionDetails(int packageId, string name, string region, string currency)
        {
            PackageInfo packageInfo = await PackageDetails.GetAsync(packageId, region);
            Assert.Equal(packageId, packageInfo.SteamPackageId);
            Assert.Equal(name, packageInfo.Name);
            Assert.Equal(currency, packageInfo.Price.Currency);

        }


        [Fact]
        public async Task GetFeatured()
        {
            FeaturedApps featured = await Featured.GetAsync();
            Assert.NotEmpty(featured.FeaturedMac);
            Assert.NotEmpty(featured.FeaturedLinux);
            Assert.NotEmpty(featured.FeaturedWin);
        }

        [Fact]
        public async Task GetFeaturedCategories()
        {
            var featuredCategories = await FeaturedCategories.GetAsync();
            Assert.NotEmpty(featuredCategories);
        }
    }
}
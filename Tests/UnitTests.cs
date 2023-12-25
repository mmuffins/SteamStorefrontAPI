using Newtonsoft.Json;
using SteamStorefrontAPI;
using SteamStorefrontAPI.Classes;
using System.Globalization;

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

        public static IEnumerable<object[]> SteamPriceStringConverterCultures =>
            new List<object[]>
            {
                new object[] { "en-US", "1000", 10.00 },
                new object[] { "en-US", "700", 7.00 },
                new object[] { "en-US", "50", 0.50 },
                new object[] { "en-US", "5899", 58.99 },
                new object[] { "en-US", "123456789", 1234567.89 },
                new object[] { "en-US", "1", 0.01 },
                new object[] { "en-US", "99", 0.99 },
                new object[] { "en-US", "0", 0.00 },
                new object[] { "en-US", "00", 0.00 },
                new object[] { "en-US", "000", 0.00 },
                new object[] { "en-US", "1000000000000", 10000000000.00 },
                new object[] { "en-US", "12345678901234", 123456789012.34 },

                new object[] { "de-DE", "1000", 10.00 },
                new object[] { "de-DE", "700", 7.00 },
                new object[] { "de-DE", "50", 0.50 },
                new object[] { "de-DE", "5899", 58.99 },
                new object[] { "de-DE", "123456789", 1234567.89 },
                new object[] { "de-DE", "1", 0.01 },
                new object[] { "de-DE", "99", 0.99 },
                new object[] { "de-DE", "0", 0.00 },
                new object[] { "de-DE", "00", 0.00 },
                new object[] { "de-DE", "000", 0.00 },
                new object[] { "de-DE", "1000000000000", 10000000000.00 },
                new object[] { "de-DE", "12345678901234", 123456789012.34 },

                new object[] { "fr-FR", "1000", 10.00 },
                new object[] { "fr-FR", "700", 7.00 },
                new object[] { "fr-FR", "50", 0.50 },
                new object[] { "fr-FR", "5899", 58.99 },
                new object[] { "fr-FR", "123456789", 1234567.89 },
                new object[] { "fr-FR", "1", 0.01 },
                new object[] { "fr-FR", "99", 0.99 },
                new object[] { "fr-FR", "0", 0.00 },
                new object[] { "fr-FR", "00", 0.00 },
                new object[] { "fr-FR", "000", 0.00 },
                new object[] { "fr-FR", "1000000000000", 10000000000.00 },
                new object[] { "fr-FR", "12345678901234", 123456789012.34 },

                new object[] { "ja-JP", "1000", 10.00 },
                new object[] { "ja-JP", "700", 7.00 },
                new object[] { "ja-JP", "50", 0.50 },
                new object[] { "ja-JP", "5899", 58.99 },
                new object[] { "ja-JP", "123456789", 1234567.89 },
                new object[] { "ja-JP", "1", 0.01 },
                new object[] { "ja-JP", "99", 0.99 },
                new object[] { "ja-JP", "0", 0.00 },
                new object[] { "ja-JP", "00", 0.00 },
                new object[] { "ja-JP", "000", 0.00 },
                new object[] { "ja-JP", "1000000000000", 10000000000.00 },
                new object[] { "ja-JP", "12345678901234", 123456789012.34 },
            };

        [Theory]
        [MemberData(nameof(SteamPriceStringConverterCultures))]
        public void SteamPriceStringConverterCulturesConversion(string culture, string valueString, double convertedValue)
        {
            var originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo(culture);

            try
            {
                var jsonReader = new JsonTextReader(new StringReader(valueString));
                jsonReader.Read();

                var converter = new SteamPriceStringConverter();
                var result = converter.ReadJson(jsonReader, null, null, new JsonSerializer());

                Assert.Equal(convertedValue, result);
            }
            finally
            {
                CultureInfo.CurrentCulture = originalCulture;
            }
        }
    }
}
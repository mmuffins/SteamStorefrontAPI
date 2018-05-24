using SteamStorefrontAPI;
using SteamStorefrontAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SteamStorefrontConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () => await GetGame()).Wait();

        }

        static async Task GetGame()
        {
            //var steamApp1 = await AppDetails.GetAsync(637670);
            //var steamApp2 = await AppDetails.GetAsync(443790);
            //var steamApp3 = await AppDetails.GetAsync(460810, "JP");
            //var steamApp4 = await AppDetails.GetAsync(322330);

            var package1 = await PackageDetails.GetAsync(68179);
            var package2 = await PackageDetails.GetAsync(68179, "JP");
            var package3 = await PackageDetails.GetAsync(235158);
            var package4 = await PackageDetails.GetAsync(235158, "US");

            //var featured = await Featured.GetAsync();
            //var featuredCategories = await FeaturedCategories.GetAsync();

            //Console.WriteLine(featured);
        }
    }
}

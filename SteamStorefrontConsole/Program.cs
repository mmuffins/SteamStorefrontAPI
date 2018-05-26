﻿using SteamStorefrontAPI;
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
            Task.Run(async () => await Examples()).Wait();
        }

        static async Task Examples()
        {
            // Get details for SteamApp with ID 443790
            SteamApp steamApp1 = await AppDetails.GetAsync(460810);

            // Get details for SteamApp with ID 443790 for region US
            SteamApp steamApp2 = await AppDetails.GetAsync(322330, "US");

            // Get details for Package with ID 68179 for region
            PackageInfo package1 = await PackageDetails.GetAsync(68179);

            // Get details for Package with ID 68179 for region JP
            PackageInfo package2 = await PackageDetails.GetAsync(68179, "JP");

            // Get a list of featured games
            FeaturedApps featured = await Featured.GetAsync();

            // Get a list of featured games for region DE
            FeaturedApps featured2 = await Featured.GetAsync("DE");

            // Get a list of featured games grouped by category
            List<FeaturedCategory> featuredCategories = await FeaturedCategories.GetAsync();

            // Get a list of featured games grouped by category for region US
            List<FeaturedCategory> featuredCategories2 = await FeaturedCategories.GetAsync("DE");
        }
    }
}

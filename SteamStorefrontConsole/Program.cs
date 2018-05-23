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
            var steamApp = Task.Run(async () => await AppDetails.GetAsync(637670)).Result;
            //var steamApp = Task.Run(async () => await AppDetails.GetAsync(443790)).Result;
            //var steamApp = await AppDetails.GetAsync(460810, "JP");

            Console.WriteLine(steamApp);
        }
    }
}

$apiKey = Read-Host "Please enter your nuget api key"
nuget pack .\SteamStorefrontAPI\SteamStorefrontAPI.csproj -Symbols -Prop Configuration=Release
nuget push SteamStorefrontAPI.*.nupkg -ApiKey $apiKey -source nuget.org
nuget push SteamStorefrontAPI.*.symbols.nupkg -ApiKey $apiKey -source https://nuget.smbsrc.net/

Read-Host
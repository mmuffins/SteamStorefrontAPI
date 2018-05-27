$apiKey = Read-Host "Please enter your nuget api key"
Get-ChildItem -File -Filter SteamStorefrontAPI.*nupkg | Remove-Item -Force
nuget pack .\SteamStorefrontAPI\SteamStorefrontAPI.csproj -Symbols -Prop Configuration=Release
nuget push SteamStorefrontAPI.*.nupkg -ApiKey $apiKey -source nuget.org
nuget push SteamStorefrontAPI.*.symbols.nupkg -ApiKey $apiKey -source https://nuget.smbsrc.net/

Read-Host
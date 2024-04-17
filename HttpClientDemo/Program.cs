// See https://aka.ms/new-console-template for more information
using HttpClientDemo;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http.Json;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .AddFilter("Microsoft", LogLevel.Trace)
        .AddFilter("System", LogLevel.Trace)
        .AddFilter("NonHostConsoleApp.Program", LogLevel.Trace)
        .AddConsole();
});
Console.WriteLine("Hello, World!");



var client  = new HttpClient();
client.BaseAddress = new Uri("https://sabatex.francecentral.cloudapp.azure.com");
var login = new UserLogin("1eea3e56-e9d7-4c72-a5a0-c12006a84949", "Aa1234567890-=");
var response = await client.PostAsJsonAsync("/api/v0/login", login);
if (response.IsSuccessStatusCode)
{
    var token = await response.Content.ReadFromJsonAsync<Token>() ?? throw new Exception("Token fail!");
    Console.WriteLine(token.AccessToken);
}


var privatApi = new PrivatBankApi();
var rate = await privatApi.GetRateAsync(DateTime.Now);
Console.WriteLine(rate.ToString());


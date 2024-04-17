// See https://aka.ms/new-console-template for more information
using HttpClientDemo;
using System.Net;
using System.Text.Json;

Console.WriteLine("Hello, World!");


var login = new { clientId = "1eea3e56-e9d7-4c72-a5a0-c12006a84949", password = "Aa1234567890-=" };
var host = new Uri("https://sabatex.francecentral.cloudapp.azure.com");


// WebClient
var url = new Uri(host, "api/v0/login");
var webClient = new WebClient();
webClient.Headers.Add("Content-Type", "application/json; charset=utf-8");
webClient.Headers.Add("accept", "*/*");
var s =  JsonSerializer.Serialize(login);
try
{
    var tokenStr = webClient.UploadString(url, "POST", s);
    var _token = JsonSerializer.Deserialize<Token>(tokenStr);
}
catch(Exception ex)
{

}

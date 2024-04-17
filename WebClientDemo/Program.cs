// See https://aka.ms/new-console-template for more information
using HttpClientDemo;
using System.Buffers.Text;
using System.Net;
using System.Text;
using System.Text.Json;
using WebClientDemo;

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

string clientId = "jhsdjsd";
string destinationId = "3434";
string token = "";


byte[] bytes = new byte[] { };
 var str =Convert.ToBase64String(bytes);

void PostQuery(string objectType, string objectId)
{
    var url = new Uri(host, "api/v0/queries");
    var webClient = new WebClient();
    webClient.Encoding = Encoding.UTF8;
    webClient.Headers.Add("Content-Type", "application/json; charset=utf-8");
    webClient.Headers.Add("accept", "*/*");
    webClient.Headers.Add("clientId", clientId.ToString());
    webClient.Headers.Add("destinationId", destinationId.ToString());
    webClient.Headers.Add("apiToken", token);
    try
    {
        var obj = new { objectType = objectType, objectId = objectId };
        string t = JsonSerializer.Serialize(obj);
        webClient.UploadString(url, "POST", t);
    }
    catch (Exception ex)
    {
        throw new Exception($"POST object to service : {ex.ToString()}");
    }
}

QueryObject[] GetQueries(int take = 10)
{
    var url = new Uri(host, $"api/v0/queries?take={take}");
    var webClient = new WebClient();
    webClient.Encoding = Encoding.UTF8;
    webClient.Headers.Add("Content-Type", "application/json; charset=utf-8");
    webClient.Headers.Add("accept", "*/*");
    webClient.Headers.Add("clientId", clientId.ToString());
    webClient.Headers.Add("destinationId", destinationId.ToString());
    webClient.Headers.Add("apiToken", token);
    try
    {
        string s = webClient.DownloadString(url);
        //var result = JsonConvert.DeserializeObject<ObjectExchange>(s,new JsonSerializerSettings {ContractResolver =new DefaultContractResolver { NamingStrategy=new CamelCaseNamingStrategy()} });
        return JsonSerializer.Deserialize<QueryObject[]>(s);


    }
    catch (Exception ex)
    {
        throw new Exception($"GET queries from service : {ex.ToString()}");
    }
}


void DeleteQuery(long id)
{
    var url = new Uri(host, $"api/v0/queries/{id}");
    //var request = HttpWebRequest.Create(url);
    var request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "DELETE";
    request.Accept = "*/*";
    request.Headers["clientId"] = clientId.ToString();
    request.Headers["apiToken"] = token;

    try
    {
        var responce = request.GetResponse();
    }
    catch (Exception ex)
    {
        throw new Exception($"Error delete query from service : {ex.ToString()}");
    }

}
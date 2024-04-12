// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Text;

Console.WriteLine("Hello, World!");


var request = (FtpWebRequest)WebRequest.Create("ftp://ftp.gnu.org");
request.Credentials = new NetworkCredential("anonymous","");
request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
try
{
    var data = new byte[10000];
    var response = (FtpWebResponse)request.GetResponse();
    var bytes = response.GetResponseStream().Read(data);
    Console.WriteLine(Encoding.ASCII.GetString(data, 0, bytes));

}catch (Exception ex)
{

}

request = (FtpWebRequest)WebRequest.Create("ftp://ftp.gnu.org/welcome.msg");
request.Credentials = new NetworkCredential("anonymous", "");
request.Method = WebRequestMethods.Ftp.DownloadFile;
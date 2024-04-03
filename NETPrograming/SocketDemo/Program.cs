// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Hello, World!");

IPAddress localhost = new IPAddress(new byte[] { 127, 0, 0, 1 });

// IP = www.google.com   //com   //google.com  // www.goodle.com    mycompany.com.ua



var google = Dns.GetHostAddresses("google.com");

IPEndPoint client = new IPEndPoint(google[0], 80);

var clientSocket = new Socket(client.AddressFamily,SocketType.Stream, ProtocolType.Tcp);
clientSocket.Connect(client);
var page = new StringBuilder();
if (clientSocket.Connected)
{
    string request = $"GET / HTTP/1.1\r\nHost: www.google.com\r\nConnection: Close\r\n\r\n";
    var bytes = Encoding.ASCII.GetBytes(request);
    var bufer = new byte[1024];
    clientSocket.Send(bytes);
    int bl = 0;
    do
    {
        bl=clientSocket.Receive(bufer,bufer.Length,0);
        page.Append(Encoding.ASCII.GetString(bufer,0, bl));

    } while(bl>0);
    Console.WriteLine(page.ToString());


}

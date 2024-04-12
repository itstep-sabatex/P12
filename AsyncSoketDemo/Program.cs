// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Hello, World!");

var server = Task.Run(() =>
{
    var udpClient = new UdpClient();
    var endPoint = new IPEndPoint(IPAddress.Any, 5000);
    udpClient.Client.Bind(endPoint);
    var state = new UdpState(udpClient, endPoint);

    var r = udpClient.BeginReceive(RecesiveCallback, state);
    Console.WriteLine("Recesive started");
});


var client = Task.Run(() =>
{
    var udpClient = new UdpClient();
    udpClient.SendAsync(Encoding.ASCII.GetBytes("Hello from client UDP"),"localhost",5000);
    Console.WriteLine("Client message sended");
});

void RecesiveCallback(IAsyncResult ar)
{
    String content = String.Empty;
    var a = ar.IsCompleted;
    var handler = ((UdpState)ar.AsyncState).u;
    var endpoint = ((UdpState)ar.AsyncState).e;
    byte[] bytes = handler.EndReceive(ar, ref endpoint);
    Console.WriteLine($"{endpoint.Address} message: {Encoding.ASCII.GetString(bytes)}");
}







Console.ReadLine();
record UdpState(UdpClient u,IPEndPoint e);
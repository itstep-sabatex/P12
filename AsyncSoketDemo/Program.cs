// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Hello, World!");

var server = Task.Run(() =>
{
    var udpClient = new UdpClient();
    udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 5000));

    var r = udpClient.BeginReceive(RecesiveCallback, null);
    Console.WriteLine("Recesive started");
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
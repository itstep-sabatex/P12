// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;
using UDPDemo;

Console.WriteLine("Hello, World!");



var udpServer = Task.Run(() => 
{
    var server = new UdpClient();
    server.Client.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000));
    while (true)
    {
        var d = server.Receive();
        Console.WriteLine($"{d.ip.Address} message : {Encoding.ASCII.GetString(d.data)}");
    }


});

var udpClient = Task.Run(() =>
{
    var client = new UdpClient();
    int i = 1;
    while (true)
    {
        client.Send(Encoding.ASCII.GetBytes($"Message {i}"), "127.0.0.1", 5000);
    }


});
var udpClient2 = Task.Run(() =>
{
    var client = new UdpClient();
    int i = 1;
    while (true)
    {
        client.Send(Encoding.ASCII.GetBytes($"Message From Client 2 {i}"), "127.0.0.1", 5000); //128 byte
    }


});
Console.ReadLine();
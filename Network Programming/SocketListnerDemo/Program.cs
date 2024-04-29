// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Hello, World!");

var clientTask = Task.Run(() =>
{
    var ipAddress = IPAddress.Parse("192.168.1.109");
    IPEndPoint serverEndpoint = new IPEndPoint(ipAddress, 5000);
   
    int i = 0;
    do
    {
        var sSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        sSocket.Connect(serverEndpoint);
        if (sSocket.Connected)
        {
            Console.WriteLine("Зєднались з сервером");
            string message = "Hello sever\r\n";
            var bytesSend = Encoding.ASCII.GetBytes(message);
            sSocket.Send(bytesSend);
            i++;
            message = $"Message {i} EOF\r\n";
            bytesSend = Encoding.ASCII.GetBytes(message);
            sSocket.Send(bytesSend);

            var buffer = new byte[4096];
            var text = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = sSocket.Receive(buffer, buffer.Length, 0);
                text.Append(Encoding.ASCII.GetString(buffer, 0, bytes));
            } while (bytes>0);
            Console.WriteLine($"Server message:{text.ToString()}");
            sSocket.Close();
        } 
        else
        {
            Console.WriteLine("Помилка зєднання.");
        }
        Thread.Sleep(1000);
    }while (true);




});


var serverTask = Task.Run(() => 
{
    var ipAddress = IPAddress.Parse("192.168.1.109");
    IPEndPoint serverEndpoint = new IPEndPoint(ipAddress, 5000);
    var sSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    try
    {
        sSocket.Bind(serverEndpoint);
        sSocket.Listen();
        do
        {
            Console.WriteLine("Чекаємо на зєднання");
            Socket handler = sSocket.Accept();
            Console.WriteLine("З'днання");
            var buffer = new byte[4096];
            var text = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = handler.Receive(buffer, buffer.Length, 0);
                text.Append(Encoding.ASCII.GetString(buffer,0,bytes));
            } while (!text.ToString().EndsWith("EOF\r\n"));
            Console.WriteLine($"Server message:{text.ToString()}");
            string responce = "By\r\n";
            var bytesSend = Encoding.ASCII.GetBytes(responce);
            handler.Send(bytesSend);
            handler.Close();
        } while(true);


    }catch (Exception ex) { }


});


Console.ReadLine();
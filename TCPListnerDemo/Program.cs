// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Hello, World!");


var tcpServer = Task.Run(() => {
    var ipAddr = IPAddress.Parse("127.0.0.1");
    var server = new TcpListener(ipAddr, 5000);
    server.Start();
    while (true)
    {
        Console.WriteLine("waiting for connection ...");
        TcpClient client = server.AcceptTcpClient();
        var buffer = new byte[1024];
        var stream = client.GetStream();
        var bytes = stream.Read(buffer, 0, buffer.Length);
        Console.WriteLine($"Received: {Encoding.ASCII.GetString(buffer,0,bytes)}");
        var response = Encoding.ASCII.GetBytes("Hello");
        stream.Write(response, 0, response.Length);
        bytes = stream.Read(buffer);
        var fileName = Encoding.ASCII.GetString(buffer, 0, bytes);
        var fs = File.OpenWrite($"n{fileName}");
        stream.Write(Encoding.ASCII.GetBytes("Ok"));
        stream.Flush();

        stream.CopyTo(fs);
        fs.Close();


        stream.Close();
        client.Close();
    }

});

var tcpClient =  Task.Run(()=>{
    var client = new TcpClient("localhost", 5000);
    var message = Encoding.ASCII.GetBytes("Hello Server!");
    var stream = client.GetStream();
    stream.Write(message);
    var buffer=new byte[1024];
    var bytes = stream.Read(buffer);
    Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytes));
    stream.Flush();
    stream.Write(Encoding.ASCII.GetBytes("test.txt"));
    stream.Flush();
    bytes = stream.Read(buffer);
    var fs = File.OpenRead("test.txt");
    fs.CopyTo(stream);

    stream.Close();
    client.Close();

});

Console.ReadLine();



// на клієнтському компютері в якості параметра командної строки передаєте  імя файла (шлях).
// файл має бути переданий на сервер і створений в каталозі сервера.
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


void dothread(object obj)
{
    var a = obj;
    Thread.Sleep(100);
    Console.WriteLine("Thread 2");
    
}

var thread = new Thread(dothread);
//thread.IsBackground=true;
thread.Start();
thread.Join();
if (thread.IsAlive)
{

}



Thread.Sleep(500);
Console.WriteLine("Main thread");
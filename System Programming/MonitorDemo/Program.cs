// See https://aka.ms/new-console-template for more information
using MonitorDemo;

Console.WriteLine("Hello, World!");
var sp = new SinchroProblem();

var t1 = Task.Run(() => sp.Increment());
var t2 = Task.Run(() => sp.Increment());


t1.Wait();
t2.Wait();

object lockObj = new object();

if (Monitor.TryEnter(lockObj,1000))
{ 
    var b = 10;
    Monitor.Exit(lockObj);
}
else
{
    Console.WriteLine("Error ---");
};
Mutex mutexNoName = new Mutex();
mutexNoName.WaitOne();
mutexNoName.ReleaseMutex();
Mutex mutex = new Mutex(true, "EA86B3DD-C55E-4A83-9DEB-3DF380DDFA8B");
mutex.WaitOne();
// Crical section

mutex.ReleaseMutex();
var mutex2 = Mutex.OpenExisting("EA86B3DD-C55E-4A83-9DEB-3DF380DDFA8B");



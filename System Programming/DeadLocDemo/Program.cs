// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
object lockerA = new object();
object lockerB = new object();
object lockerC = new object();
object lockerD = new object();

void MethodA()
{
       Console.WriteLine("StART A");
        lock (lockerA)
        {
            MethodC();
        }
        Console.WriteLine("End A");
}

void MethodC()
{
    Console.WriteLine("StART C");
    lock (lockerC)
    {
        MethodA();
        lock (lockerD)
        {
            MethodB();
        }
        
    }
}

void MethodD()
{
    Console.WriteLine("StART D");
    lock (lockerC)
    { 
        MethodB();
        MethodA();
    }
}
void MethodB()
{
    lock (lockerD)
    {
        Console.WriteLine("StART B");
        lock (lockerB)
        {
            Console.WriteLine("Thread B");
            MethodA();
        }
        Console.WriteLine("End B");
    }
}

    Task.Run(() => MethodD());
    Task.Run(() => MethodC());
    Console.ReadKey();


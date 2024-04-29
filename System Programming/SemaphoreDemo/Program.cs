// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var semaphore = new Semaphore(2, 2, "9F633EE0-BD71-4F4C-A9DB-FFD865FC2D64");
for (int i = 0; i < 100; i++)
{
    if (semaphore.WaitOne(2000))
    {
        Console.WriteLine($"Counter {i}");
        Thread.Sleep(1000);
        semaphore.Release();
    }
    else
    {
        Console.WriteLine("error");
    
    }
}

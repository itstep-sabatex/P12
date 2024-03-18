// See https://aka.ms/new-console-template for more information

static Task<double> MultiplreOneElement(int dim, int i, int j, double[,] a, double[,] b)
{
    double result = 0;
    for (int mi = 0; mi < dim; mi++)
    {
        result = result + a[i, mi] * b[mi, j];
    }
    return Task.FromResult(result);
}



var a = new double[1, 1];

File.

var ts = Task<double>.Run(() => MultiplreOneElement(1, 1, 1, a, a));
Task<double> Calc(double a, double b)
{
    return Task.FromResult( a + b);
}

async Task<double> CalcAsync(double a, double b)
{
    await Task.Yield();
    return a + b;
    
}

var tasync = CalcAsync(25, 65);
tasync.Wait();
tasync.
var result = tasync.Result;

Console.WriteLine(await CalcAsync(25, 65));


var t3 = Calc(6, 7);
var t4 = Calc(16, 37);
 t3.Wait();
 Console.WriteLine(t3.Result);





await Task.Run(() =>
{
    Thread.Sleep(4000);
    Console.WriteLine("Hello, World!");
    
});



await Task.Run(() =>
{
    Thread.Sleep(4000);
    Console.WriteLine("Hello, World!");
    
});
//t1.Wait();
//t2.Wait();

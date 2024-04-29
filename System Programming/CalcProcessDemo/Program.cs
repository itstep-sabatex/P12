// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int sum = 0;
foreach (var arg  in args)
{
    if (int.TryParse(arg, out int numbrer))
    {
        sum += numbrer;
    }
}

//Environment.ExitCode = sum; 

Environment.Exit(sum);

//return sum;
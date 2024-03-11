// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");
if (args.Length > 0)
{
    var arg0 = args[0];
    if (arg0 == "debug")
    {
        Console.WriteLine("IsDebuging");
    }
}


using (Process process = new Process())
{
    process.StartInfo.FileName = "C:\\Users\\serhi\\source\\repos\\sabatex-itstep\\P12\\CalcProcessDemo\\bin\\Debug\\net8.0\\CalcProcessDemo.exe 10 20 30";
    process.StartInfo.WorkingDirectory = "C:\\Users\\serhi\\source\\repos\\sabatex-itstep\\P12\\CalcProcessDemo\\bin\\Debug\\net8.0";
    process.StartInfo.Arguments = "10 20 30";
    
    process.StartInfo.RedirectStandardError = true;
    process.StartInfo.RedirectStandardOutput = true;
    process.OutputDataReceived += (a,message) => Console.WriteLine($"Перенаправлене повідомлення {message}");
    process.ErrorDataReceived += (a, message) => Console.WriteLine($"Перенаправлене повідомлення помилки {message}");
    process.Start();
    process.BeginErrorReadLine();
    process.BeginOutputReadLine();
    process.WaitForExit();
    File.AppendAllLines("file path", new string[] { "message" });
    Console.WriteLine(process.ExitCode);

}

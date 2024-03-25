// See https://aka.ms/new-console-template for more information
using Microsoft.Win32;

Console.WriteLine("Hello, World!");
var value = Registry.LocalMachine.OpenSubKey("Software\\Mozilla\\MaintenanceService");
if (value != null)
{

    var r = value.GetValue("Attempted");
    Console.WriteLine(r);
}
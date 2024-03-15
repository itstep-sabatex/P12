// See https://aka.ms/new-console-template for more information
using DllImportDemo;
using System.Diagnostics;
using System.Runtime.InteropServices;


[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
static extern void MessageBox(IntPtr hWhd, string test, string caption, uint uType = 0x02);
IntPtr ptr = Process.GetCurrentProcess().MainWindowHandle;
var a = DLLDemo.Add(25, 36);
Console.WriteLine(a);

MessageBox(ptr, "Hello world", "Test");

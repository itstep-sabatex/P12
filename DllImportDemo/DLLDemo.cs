using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DllImportDemo
{
    internal static class DLLDemo
    {
        [DllImport(@"dlldemo.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Add(double a, double b);
        [DllImport(@"C:\Users\serhiy\source\repos\SystemPromming\Debug\DemoDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Mul(double a, double b);

        [DllImport(@"C:\Users\serhiy\source\repos\SystemPromming\Debug\DemoDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Div(double a, double b);

        [DllImport(@"C:\Users\serhiy\source\repos\SystemPromming\Debug\DemoDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Sub(double a, double b);


    }
}

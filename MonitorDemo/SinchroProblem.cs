using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MonitorDemo
{
    internal class SinchroProblem
    {
        volatile int count;

        public  int Count { get; set; } = 0;

        public void Increment()
        {
            for (int i = 0; i < 100; i++)
            {
                Count++; // 1 - отримання значення з памяті, 2 - інкремент значення, 3 - запис значення в память
                Thread.Sleep(100);
                Console.WriteLine(Count.ToString());
            }
        }
    }
}

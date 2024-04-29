using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorDemo
{
    internal class SinchroNoProblem
    {
        volatile int count;

        public int Count { get; set; } = 0;
        private object refObject = new object();

        public void Increment()
        {
            for (int i = 0; i < 100; i++)
            {
                lock (refObject) //Monitor
                {
                    Count++; // 1 - отримання значення з памяті, 2 - інкремент значення, 3 - запис значення в память
                    //DeadLock
                    Console.WriteLine(Count.ToString());
                }
               
            }
        }
    }
}

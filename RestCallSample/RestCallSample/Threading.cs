using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestCallSample
{
    class ThreadingTest
    {
        public static void testThreading()
        {
            ThreadStart threadStart = new ThreadStart(threadMethod);
            Thread t = new Thread(threadStart);
            t.Start();
            Console.WriteLine("after thread start call");
        }
        static void threadMethod()
        {
            Console.ReadLine();
            Console.WriteLine("In thread method");
            Console.ReadLine();
        }
    }
}

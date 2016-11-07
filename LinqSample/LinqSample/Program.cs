using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] {2, 54, 78, 898, 7888};
            IEnumerable<int> y = from x in arr where x < 60 select x;
            Console.WriteLine(y);
            foreach(int t in y)
            {
                Console.WriteLine(t + " ");
            }
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            try
            {
                p.sequenceCall();
            }
            catch (Exception e)
            {
                int d = 23;

            }
            
        }

        private void sequenceCall()
        {
            try
            {
                call1();
            }
            catch (Exception e)
            {
                throw;
            }
            
           

        }

        private void call1()
        {
            try
            {
                call2();
                int d = 23;
            }
            catch (Exception e)
            {
                Console.WriteLine("uuuuuu");
                throw;
            }
            
        }

        private void call2()
        {
            try
            {
                Console.WriteLine("in exc handlier");

                Console.WriteLine("in exc handlier");

                Console.WriteLine("in exc handlier");

                call3();
                Console.WriteLine("in ALKNFDKJAF");

                Console.WriteLine("in ======");
                Console.Read();

            }
            catch (Exception e)
            {
                Console.WriteLine("in uauuu");
                throw;
                Console.Read();
            }
            Console.WriteLine();
            
        }

        private void call3()
        {
            int d = 0;
            int ae = d/0;
        }
    }
}

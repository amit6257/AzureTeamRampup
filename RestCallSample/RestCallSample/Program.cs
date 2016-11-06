using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
// ReSharper disable All

namespace RestCallSample
{
    class Program
    {
        public static void Main(string[] args)
        {
            //SimpleRestCallSync();
            //SimpleRestCallASync();
            //ThreadingTest.testThreading();
           TestSimpleTask();
        }

        private static void TestSimpleTask()
        {
            Task t = Task.Run(() => {
                Console.WriteLine("Sleeping for 3 sec");
                Thread.Sleep(3000);
                Console.WriteLine("Wake up from sleep of 3 sec");
            });

            /*To wait for a single task to complete, you can call its Task.Wait method. A call to 
            the Wait method blocks the calling thread until the single class instance has completed
            execution.*/
            Console.WriteLine("calling task.wait");
            t.Wait();
            Console.WriteLine("task done");
            Console.ReadLine();
        }

        private static void SimpleRestCallASync()
        {
            Console.WriteLine("Starting network async call");
            ThreadStart ts = new ThreadStart(SimpleRestCallSync);
            Thread t = new Thread(ts);
            t.Start();
            Console.WriteLine("End of async call");
        }
        
        // This is a synchronous rest call
        private static void SimpleRestCallSync()
        {
            string url = "http://stackoverflow.com/questions/27108264/c-sharp-how-to-properly-make-a-http-web-get-request";

            Console.WriteLine("starting sync network call");
            for(int i = 0;i<10;i++)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                // default is GET method
                // request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();

                if (resStream != null)
                {
                    StreamReader reader = new StreamReader(resStream);
                    string res = reader.ReadToEnd();
                    //Console.WriteLine(res);
                }
            }
            
            Console.WriteLine("This is printed at end, i.e it is a sync call");
            Console.ReadLine();
        }
    }
}

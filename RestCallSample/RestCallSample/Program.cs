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

namespace RestCallSample
{
    class Program
    {
        public static void Main(string[] args)
        {
            //simpleRestCallSync();
            simpleRestCallASync();
            //ThreadingTest.testThreading();
        }

        private static void simpleRestCallASync()
        {
            Console.WriteLine("Starting network async call");
            ThreadStart ts = new ThreadStart(simpleRestCallSync);
            Thread t = new Thread(ts);
            t.Start();
            Console.WriteLine("End of async call");
        }
        
        // This is a synchronous rest call
        private static void simpleRestCallSync()
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

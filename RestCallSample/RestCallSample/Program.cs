using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestCallSample
{
    class Program
    {
        public static void Main(string[] args)
        {
            string url = "http://stackoverflow.com/questions/27108264/c-sharp-how-to-properly-make-a-http-web-get-request";

            Console.WriteLine("start");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // default is GET method
            // request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();

            if (resStream != null)
            {
                StreamReader reader = new StreamReader(resStream);
                string res = reader.ReadToEnd();
                Console.WriteLine(res);
            }

            Console.WriteLine("end");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CertPickerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cert = GetCert();
        }

        private static object GetCert()
        {
            string thumbprint = "B21D10D7279AA4C2E89AE25F19E4634DF26A50DB";
            X509Store x509Store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            x509Store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certificate2Collection = x509Store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
            var cert = certificate2Collection[0];

            return cert;
        }
    }
}

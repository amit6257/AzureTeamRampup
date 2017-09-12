using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Azure.KeyVault;
using MyAspnetWebApp.AAD;

namespace MyAspnetWebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Task task = GetSecretFromKeyVaultUsingAadToken();
        }

        private static async Task GetSecretFromKeyVaultUsingAadToken()
        {
            // I put my GetToken method in a Utils class. Change for wherever you placed your method.
            var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(AadUtility.GetToken));

            var sec = await kv.GetSecretAsync(WebConfigurationManager.AppSettings["SecretUri"]);

            //I put a variable in a Utils class to hold the secret for general  application use.
            AadUtility.EncryptSecret = sec.Value;
        }
    }
}

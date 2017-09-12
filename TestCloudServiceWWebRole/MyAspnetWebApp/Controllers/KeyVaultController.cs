using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyAspnetWebApp.AAD;

namespace MyAspnetWebApp.Controllers
{
    public class KeyVaultController : ApiController
    {
        public object GetPwdFromKeyVault()
        {
            // the secret was pulled during app start.
            return new
            {
                secret = AadUtility.EncryptSecret
            };
        }
    }
}

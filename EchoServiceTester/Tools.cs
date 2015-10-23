using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Description;
using System.Security.Cryptography.X509Certificates;

namespace EchoServiceTester
{
    public class Tools
    {
        public static void SetupCert(ServiceCredentials credentials)
        {
            credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, "zhiqiang.com");
            credentials.ClientCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;
        }
    }
}

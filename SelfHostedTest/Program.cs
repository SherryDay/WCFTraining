using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace SelfHostedTest
{
    class Program
    {
        static void Main(string[] args)
        { 
            string address = "http://localhost:8090/SelfHostService/HelloWorldSerivce";

            Uri httpUrl = new Uri(address);

            ServiceHost host = new ServiceHost(typeof(SelfHostService.HelloWorldService), httpUrl);

            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

            host.AddServiceEndpoint(typeof(SelfHostService.IHelloWorldService), binding, address);
            host.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
            host.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new MyCustomValidator();

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);

            host.Open();
            Console.WriteLine("Service is host at " + address);
            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadLine();
        }
    }
}

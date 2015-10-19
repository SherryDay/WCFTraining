using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

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
            host.AddServiceEndpoint(typeof(SelfHostService.IHelloWorldService), new BasicHttpBinding(), address);

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

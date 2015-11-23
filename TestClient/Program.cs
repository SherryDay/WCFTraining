using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;
using SelfHostService;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorldService.HelloWorldServiceClient client = new HelloWorldService.HelloWorldServiceClient();
            //client.ClientCredentials.UserName.UserName = "h";
            //client.ClientCredentials.UserName.Password = "p";
            //Console.WriteLine("result =" + client.GetMessage("zhiqiang1"));

            Console.WriteLine("Client is running at " + DateTime.Now.ToString());
            Console.WriteLine("result =" + SelfHostServiceProxy.GetMessage("Zhiqiang"));
            Console.ReadLine();
        }
    }
}

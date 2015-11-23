using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SelfHostService;

namespace ChannelLearningTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "http://localhost:8090/SelfHostService/HelloWorldSerivce";
            using (ServiceHost host = new ServiceHost(typeof(HelloWorldService)))
            {
                host.AddServiceEndpoint(typeof(IHelloWorldService), new SimpleDatagramBinding(), address);
                host.Open();
            }

            using (ChannelFactory<IHelloWorldService> channelFactory = new ChannelFactory<IHelloWorldService>(new SimpleDatagramBinding(), "http://localhost:8090/SelfHostService/HelloWorldSerivce"))
            {
                IHelloWorldService proxy = channelFactory.CreateChannel();
                proxy.GetMessage("first call!!!");
                Console.WriteLine("Done!");
                (proxy as ICommunicationObject).Close();
            }
            
        }
    }
}

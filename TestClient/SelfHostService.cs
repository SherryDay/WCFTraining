using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SelfHostService;

namespace TestClient
{
    public static class SelfHostService
    {
        public static string GetMessage(string name)
        {
            string baseAddress = "http://localhost:8090/SelfHostService/HelloWorldSerivce";
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress remoteAddress = new EndpointAddress(baseAddress);
            ChannelFactory<IHelloWorldService> factory = new ChannelFactory<IHelloWorldService>(binding, remoteAddress);

            IHelloWorldService proxy = factory.CreateChannel();

            string result = proxy.GetMessage(name);

            factory.Close();

            return result;
        }
    }
}

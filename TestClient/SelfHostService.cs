using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace TestClient
{
    public static class SelfHostServiceProxy
    {
        public static string GetMessage(string name)
        {
            string baseAddress = "http://localhost:8090/SelfHostService/HelloWorldSerivce";
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

            EndpointAddress remoteAddress = new EndpointAddress(baseAddress);

            ChannelFactory<HelloWorldService.IHelloWorldService> factory = new ChannelFactory<HelloWorldService.IHelloWorldService>(binding, remoteAddress);

            factory.Credentials.UserName.UserName = "h";
            factory.Credentials.UserName.Password = "p";

            HelloWorldService.IHelloWorldService proxy = factory.CreateChannel();

            string result = proxy.GetMessage(name);

            factory.Close();

            return result;
        }
    }
}

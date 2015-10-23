using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.IO;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Net;

namespace EchoServiceTester
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTests();
        }
        private static void RunTests()
        {
            string securityAddress = string.Format("https://localhost:443/IISHost/EchoService/HelloWorld.svc/safe");
            string address = string.Format("http://localhost:80/IISHost/EchoService/HelloWorld.svc/safe");
            WSHttpBinding binding = new WSHttpBinding(SecurityMode.TransportWithMessageCredential);

            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

            InvokeServiceOperations(securityAddress, binding);

        }

        private static void InvokeServiceOperations(string address, Binding binding)
        {
            Console.WriteLine("Testing service operations using a binding with the following elements:");
            DescribeBinding(binding);

            TestEcho(address, binding);
            TestUploadStream(address, binding);
            TestDownloadStream(address, binding);

            Console.WriteLine("Test passed.");
        }

        static void DescribeBinding(Binding binding)
        {
            foreach (BindingElement element in (new CustomBinding(binding)).Elements)
            {
                Console.WriteLine(element.GetType().Name);
            }
        }

        static void TestEcho(string address, Binding binding)
        {
            ChannelFactory<IHelloWorld> channelFactory = new ChannelFactory<IHelloWorld>(binding, address);
            ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
            channelFactory.Credentials.UserName.UserName = "h";
            channelFactory.Credentials.UserName.Password = "p";
            IHelloWorld client = channelFactory.CreateChannel();
            ((IChannel)client).Open();

            Console.WriteLine("Invoking Echo... Response = {0}", client.SayHello("zhiqiang"));
            ((IChannel)client).Close();
        }


        static void TestUploadStream(string address, Binding binding)
        {
            byte[] buffer = new byte[1024];
            Random rand = new Random();
            rand.NextBytes(buffer);

            MemoryStream stream = new MemoryStream(buffer);

            ChannelFactory<IHelloWorld> channelFactory = new ChannelFactory<IHelloWorld>(binding, address);
            ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
            channelFactory.Credentials.UserName.UserName = "h";
            channelFactory.Credentials.UserName.Password = "p";
            IHelloWorld client = channelFactory.CreateChannel();
            ((IChannel)client).Open();

            Console.WriteLine("Invoking UploadStream...");
            client.UploadStream(stream);

            ((IChannel)client).Close();
        }

        static void TestDownloadStream(string address, Binding binding)
        {
            ChannelFactory<IHelloWorld> channelFactory = new ChannelFactory<IHelloWorld>(binding, address);
            ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
            channelFactory.Credentials.UserName.UserName = "h";
            channelFactory.Credentials.UserName.Password = "p";
            IHelloWorld client = channelFactory.CreateChannel();
            ((IChannel)client).Open();

            Console.WriteLine("Invoking DownloadStream...");
            Stream stream = client.DownloadStream();

            int readResult;
            int bytesRead = 0;
            byte[] buffer = new byte[1000];
            do
            {
                readResult = stream.Read(buffer, 0, buffer.Length);
                bytesRead += readResult;
            }
            while (readResult != 0);

            stream.Close();

            Console.WriteLine("Read {0} bytes.", bytesRead);

            ((IChannel)client).Close();
        }

        [ServiceContract]
        public interface IHelloWorld
        {
            [OperationContract]
            string SayHello(string name);

            [OperationContract]
            Stream DownloadStream();

            [OperationContract]
            void UploadStream(Stream stream);
        }
    }
}

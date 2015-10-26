using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace DuplexStreamingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTests();
        }

        private static void RunTests()
        {

            string address = "net.tcp://localhost/IISHost/DuplexStreamService/DuplexService.svc";
            //string address = "http://localhost/DuplexStreamingService45//Duplex.svc";
            //NetHttpBinding binding = new NetHttpBinding();
            //binding.WebSocketSettings.TransportUsage = WebSocketTransportUsage.Always;
            //binding.MaxReceivedMessageSize = int.MaxValue;
            //binding.TransferMode = TransferMode.Streamed;

            NetTcpBinding binding = new NetTcpBinding();

            ClientReceiver clientReceiver = new ClientReceiver();

            DuplexChannelFactory<IDuplexService> channelFactory = new DuplexChannelFactory<IDuplexService>(new InstanceContext(clientReceiver), binding, address);
            IDuplexService client = channelFactory.CreateChannel();

            Console.WriteLine(client.DownloadData());

            // Test bi-directional streaming

            Console.WriteLine("Invoking StartPushingStream - get the server to push a stream to the client.");
            client.StartPushingStream();

            // Wait for the callback to get invoked before telling the service to stop streaming.
            // This ensures we can read from the stream on the callback while the NCL layer at the service
            // is still writing the bytes from the stream to the wire.  
            // This will deadlock if the transfer mode is buffered because the callback will wait for the
            // stream, and the NCL layer will continue to buffer the stream until it reaches the end.

            Console.WriteLine("Waiting on ReceiveStreamInvoked from the ClientReceiver.");
            clientReceiver.ReceiveStreamInvoked.WaitOne();
            clientReceiver.ReceiveStreamInvoked.Reset();

            // Upload the stream while we are downloading a different stream
            Console.WriteLine("Invoking UploadStream, while the ClientReceiver is receiving bytes");
            FlowControlledStream uploadStream = new FlowControlledStream();
            uploadStream.ReadThrottle = TimeSpan.FromMilliseconds(500);
            uploadStream.StreamDuration = TimeSpan.FromSeconds(1);
            client.UploadStream(uploadStream);

            Console.WriteLine("Invoking StopPushingStream");
            client.StopPushingStream();
            Console.WriteLine("Waiting on ReceiveStreamCompleted from the ClientReceiver.");
            clientReceiver.ReceiveStreamCompleted.WaitOne();
            clientReceiver.ReceiveStreamCompleted.Reset();

            Console.WriteLine("Getting results from server via callback.");
            client.GetLog();
            clientReceiver.LogReceived.WaitOne();

            Console.WriteLine("----Following are the logs from the server:-----");
            foreach (string serverLogItem in clientReceiver.ServerLog)
            {
                Console.WriteLine(serverLogItem);
            }
            Console.WriteLine("---------------- End server log. ---------------");

            ((IChannel)client).Close();

            Console.WriteLine("Test passed.");
        }
    }
}

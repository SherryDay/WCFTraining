using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri listenUri = new Uri("http://127.0.0.1:9999/listener");
            Binding binding = new BasicHttpBinding();
            IChannelFactory<IRequestChannel> channelFactory = binding.BuildChannelFactory<IRequestChannel>();
            channelFactory.Open();

            IRequestChannel channel = channelFactory.CreateChannel(new EndpointAddress(listenUri));
            channel.Open();

            Message replyMessage = channel.Request(CreateRequestMessage(binding));
            Console.WriteLine("the reply message\n{0}", replyMessage);

            Console.Read();
        }
        static Message CreateRequestMessage(Binding binding)
        {
            string action = "v-zhidu/request";
            string body = "This is a test response message.";
            return Message.CreateMessage(binding.MessageVersion, action, body);
        }
    }
}

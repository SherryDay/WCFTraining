using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;

namespace Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri listenUri = new Uri("http://127.0.0.1:9999/listener");
            Binding binding = new BasicHttpBinding();

            IChannelListener<IReplyChannel> channelListener = binding.BuildChannelListener<IReplyChannel>(listenUri);
            channelListener.Open();

            IReplyChannel channel = channelListener.AcceptChannel(TimeSpan.MaxValue);
            channel.Open();
            Console.WriteLine("Start to listening.....");

            while(true)
            {
                RequestContext requestContext = channel.ReceiveRequest(TimeSpan.MaxValue);
                Console.WriteLine("received the requestMessage:\n{0}", requestContext.RequestMessage);
                requestContext.Reply(CreateReplyMessage(binding));
            }
        }

        static Message CreateReplyMessage(Binding binding)
        {
            string action = "v-zhidu/reply";
            string body = "This is a test response message.";
            return Message.CreateMessage(binding.MessageVersion, action, body);
        }
    }
}

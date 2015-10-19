using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace DuplexStreamingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            InstanceContext instanceContext = new InstanceContext(new DuplexStreamingService.PushCallback());
            using (DuplexChannelFactory<DuplexStreamingService.IDuplexService> channelFactory = new DuplexChannelFactory<DuplexStreamingService.IDuplexService>(instanceContext, "DuplexService"))
            {
                DuplexStreamingService.IDuplexService proxy = channelFactory.CreateChannel();
                using (proxy as IDisposable)
                {
                    proxy.UploadData("duzhiqiang");
                    Console.Read();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplexStreamingService
{
    public class PushCallback : IPushCallback
    {
        public void ReceivedData(string data)
        {
            Console.WriteLine($"{data}");
        }
    }
}

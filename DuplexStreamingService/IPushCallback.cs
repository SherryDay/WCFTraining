using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;

namespace DuplexStreamingService
{
    public interface IPushCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceivedData(string data);
    }
}

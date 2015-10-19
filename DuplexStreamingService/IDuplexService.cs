using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace DuplexStreamingService
{
    [ServiceContract(CallbackContract = typeof(IPushCallback))]
    public interface IDuplexService
    {
        // request-reply
        [OperationContract]
        void UploadData(string data);
    }
}

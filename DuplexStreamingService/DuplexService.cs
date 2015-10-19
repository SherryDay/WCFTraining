using System.Collections.Generic;
using System.ServiceModel;

namespace DuplexStreamingService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class DuplexService : IDuplexService
    {
        List<string> log = new List<string>();

        public void UploadData(string data)
        {
            IPushCallback callback = OperationContext.Current.GetCallbackChannel<IPushCallback>();
            callback.ReceivedData(data);
        }
    }
}

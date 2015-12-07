using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IISHost.BroadcastorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBroadcastorService" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IBroadcastorCallback))]
    public interface IBroadcastorService
    {
        [OperationContract(IsOneWay = true)]
        void RegisterClient(string clientName);

        [OperationContract(IsOneWay = true)]
        void NotifyServer(EventDataType eventData);
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IISHost.DuplexStreamingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDuplexService" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IPushCallback))]
    public interface IDuplexService
    {
        //Request-reply operation
        [OperationContract]
        void UploadData(string data);

        [OperationContract]
        string DownloadData();

        [OperationContract(IsOneWay = true)]
        void UploadStream(Stream stream);

        [OperationContract]
        Stream DownloadStream();

        //Duplex operation
        [OperationContract(IsOneWay = true)]
        void StartPushingData();

        [OperationContract(IsOneWay = true)]
        void StopPushingData();

        [OperationContract(IsOneWay = true)]
        void StartPushingStream();

        [OperationContract(IsOneWay = true)]
        void StopPushingStream();

        //Logging
        [OperationContract(IsOneWay = true)]
        void GetLog();


    }
}

using System.IO;
using System.ServiceModel;

namespace DuplexStreamingClient
{
    [ServiceContract(CallbackContract = typeof(IPushCallback))]
    public interface IDuplexService
    {
        // Request-Reply operations
        [OperationContract]
        void UploadData(string data);

        [OperationContract]
        string DownloadData();

        [OperationContract(IsOneWay = true)]
        void UploadStream(Stream stream);

        [OperationContract]
        Stream DownloadStream();

        // Duplex operations
        [OperationContract(IsOneWay = true)]
        void StartPushingData();

        [OperationContract(IsOneWay = true)]
        void StopPushingData();

        [OperationContract(IsOneWay = true)]
        void StartPushingStream();

        [OperationContract(IsOneWay = true)]
        void StopPushingStream();

        // Logging
        [OperationContract(IsOneWay = true)]
        void GetLog();
    }
}
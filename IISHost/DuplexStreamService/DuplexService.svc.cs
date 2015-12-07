using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace IISHost.DuplexStreamingService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class DuplexService : IDuplexService
    {
        List<string> log = new List<string>();
        private static int seed = DateTime.Now.Millisecond;
        static Random rand = new Random(seed);
        static bool continuePushingData;

        static FlowControlledStream localStream;

        #region Request-reply operation
        public void UploadData(string data)
        {
            log.Add($"UploadData received {data}");
        }

        public string DownloadData()
        {
            string data = CreateInterestingString(rand.Next(512, 4096));
            log.Add($"DownloadData return {data}");

            return data;
        }
        

        public void UploadStream(Stream stream)
        {
            int readResult;
            int bytesRead = 0;
            byte[] buffer = new byte[1000];
            do
            {
                readResult = stream.Read(buffer, 0, buffer.Length);
                bytesRead += readResult;
            } while (readResult != 0);

            stream.Close();
            log.Add($"UploadStream read {bytesRead} bytes from client's stream");
        }

        public Stream DownloadStream()
        {
            log.Add("DowwnloadStream...");
            FlowControlledStream stream = new FlowControlledStream();
            stream.StreamDuration = TimeSpan.FromSeconds(1);
            stream.ReadThrottle = TimeSpan.FromMilliseconds(500);

            return stream;
        }
        #endregion

        #region Duplex operation
        public void StartPushingData()
        {
            log.Add("StartPushingData");
            continuePushingData = true;
            IPushCallback pushCallPackChannel = OperationContext.Current.GetCallbackChannel<IPushCallback>();
            ThreadPool.QueueUserWorkItem(new WaitCallback(PushData), pushCallPackChannel);
        }

        public void StopPushingData()
        {
            log.Add("StopPushingData");
            continuePushingData = false;
        }

        public void StartPushingStream()
        {
            log.Add("StartPushingStream");
            IPushCallback pushCallbackChannel = OperationContext.Current.GetCallbackChannel<IPushCallback>();
            ThreadPool.QueueUserWorkItem(new WaitCallback(PushStream), pushCallbackChannel);
        }

        public void StopPushingStream()
        {
            log.Add("StopPushingStream");
            localStream.StopStreaming = true;
        }

        public void GetLog()
        {
            IPushCallback pushCallbackChannel = OperationContext.Current.GetCallbackChannel<IPushCallback>();
            pushCallbackChannel.ReceiveLog(log);
        }

        private static void PushData(object state)
        {
            IPushCallback pushCallPackChannel = state as IPushCallback;

            do
            {
                pushCallPackChannel.ReceiveData(CreateInterestingString(rand.Next(4, 256)));
            } while (continuePushingData);

            pushCallPackChannel.ReceiveData("Last Message");
        }

        void PushStream(object state)
        {
            IPushCallback pushCallbackChannel = state as IPushCallback;
            localStream = new FlowControlledStream();
            localStream.ReadThrottle = TimeSpan.FromMilliseconds(800);

            pushCallbackChannel.ReceiveStream(localStream);
        }

        #endregion

        private static string CreateInterestingString(int length)
        {
            char[] chars = new char[length];
            int index = 0;

            if (length%2 == 1)
            {
                chars[index] = 'a';
                index++;
            }

            int seed = DateTime.Now.Millisecond;
            Random rand = new Random(seed);

            while (index < length)
            {
                var highSurrogate = Convert.ToChar(rand.Next(0xD800, 0xDC00));
                var lowSurrogate = Convert.ToChar(rand.Next(0xDC00, 0xE000));

                chars[index] = highSurrogate;
                ++index;
                chars[index] = lowSurrogate;
                ++index;
            }

            return new string(chars, 0, chars.Length);
        }
    }
}

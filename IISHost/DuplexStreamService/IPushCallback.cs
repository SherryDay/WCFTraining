﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IISHost.DuplexStreamingService
{
    public interface IPushCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveData(string data);

        [OperationContract(IsOneWay = true)]
        void ReceiveStream(Stream stream);

        [OperationContract(IsOneWay = true)]
        void ReceiveLog(List<string> log);
    }
}

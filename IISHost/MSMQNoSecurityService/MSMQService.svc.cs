using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IISHost.MSMQNoSecurityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MSMQService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MSMQService.svc or MSMQService.svc.cs at the Solution Explorer and start debugging.
    public class MSMQService : IMSMQService
    {
        public void ShowMessage(string message)
        {
            Debug.WriteLine(message + "Received at:" + DateTime.Now.ToString());
        }
    }
}

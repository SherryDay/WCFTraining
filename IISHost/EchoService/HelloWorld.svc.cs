using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Security;
using System.Security.Permissions;

namespace IISHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HelloWorld" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HelloWorld.svc or HelloWorld.svc.cs at the Solution Explorer and start debugging.
    public class HelloWorld : IHelloWorld
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "ADMIN")]
        public string SayHello(string name)
        {
            return "hello , " + name;
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "USER")]
        public Stream DownloadStream()
        {
            byte[] buffer = new byte[1024];
            Random rand = new Random();
            rand.NextBytes(buffer);

            MemoryStream stream = new MemoryStream(buffer);
            return stream;
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
        }
    }
}

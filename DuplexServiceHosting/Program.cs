﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
namespace DuplexServiceHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(DuplexStreamingService.DuplexService)))
            {
                host.Open();
                Console.WriteLine("DuplexService is running......");
                Console.Read();
            }
        }
    }
}

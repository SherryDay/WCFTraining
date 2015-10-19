using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client is running at " + DateTime.Now.ToString());
            Console.WriteLine("Sum of two numbers... 5+5 =" + SelfHostService.GetMessage("Zhiqiang"));
            Console.ReadLine();

        }
    }
}

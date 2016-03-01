using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MobileWCF.ServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri[] addressBase = new Uri[] { new Uri("http://192.168.106.164:9003/CalculatorService") };
            var host = new ServiceHost(typeof(CalculatorServiceAsyncAPM), addressBase);
            host.Open();
            Console.Read();
        }
    }
}

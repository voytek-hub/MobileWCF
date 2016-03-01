using MobileWCF.Contracts;
using MobileWCF.Domain.Interfaces;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace MobileWCF.Proxies
{
    public class CalculatorProxy : ICalculatorProxy
    {
        private ICalculatorService proxy;

        public CalculatorProxy()
        {
            string address = "http://192.168.106.164:9003/CalculatorService";
            Uri addressBase = new Uri(address);
            EndpointAddress endpoint = new EndpointAddress(address);
            BasicHttpBinding bHttp = new BasicHttpBinding();
            ChannelFactory<ICalculatorService> channel = new ChannelFactory<ICalculatorService>(bHttp, endpoint);
            proxy = channel.CreateChannel(endpoint);
        }

        public async Task<string> GetSum(int a, int b)
        {
            Task<string> getDataTask = new TaskFactory()
                .FromAsync(proxy.BeginGetSum, proxy.EndGetSum, a, b, null, TaskCreationOptions.None);

            return await getDataTask;
        }
    }
}

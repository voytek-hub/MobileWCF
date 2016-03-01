using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MobileWCF.Contracts;

namespace MobileWCF.Proxies
{
    public class CalculatorProxy : ICalculatorServiceAsyncTAP
    {
        private ICalculatorServiceAsyncTAP proxy = null;

        public CalculatorProxy()
        {
            string address = "http://192.168.106.164:9003/CalculatorService";
            Uri addressBase = new Uri(address);
            EndpointAddress endpoint = new EndpointAddress(address);
            BasicHttpBinding bHttp = new BasicHttpBinding();
            ChannelFactory<ICalculatorServiceAsyncTAP> channel = new ChannelFactory<ICalculatorServiceAsyncTAP>(bHttp, endpoint);
            proxy = channel.CreateChannel(endpoint);
        }

        public async Task<string> GetSum(int a, int b)
        {
            return await proxy.GetSum(a, b);
        }
    }

    public class CalculatorProxyAPM : ICalculatorServiceAsyncAPM
    {
        private ICalculatorServiceAsyncAPM proxy = null;

        public CalculatorProxyAPM()
        {
            string address = "http://192.168.106.164:9003/CalculatorService";
            Uri addressBase = new Uri(address);
            EndpointAddress endpoint = new EndpointAddress(address);
            BasicHttpBinding bHttp = new BasicHttpBinding();
            ChannelFactory<ICalculatorServiceAsyncAPM> channel = new ChannelFactory<ICalculatorServiceAsyncAPM>(bHttp, endpoint);
            proxy = channel.CreateChannel(endpoint);
        }

        public IAsyncResult BeginGetSum(int a, int b, AsyncCallback callback, object state = null)
        {
            return proxy.BeginGetSum(a, b, callback, proxy);
        }

        public string EndGetSum(IAsyncResult asyncResult)
        {
            return proxy.EndGetSum(asyncResult);
        }
    }
}

using MobileWCF.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MobileWCF.Proxies
{
    public class CalculatorProxyAsync<T> : ICalculatorProxy
    {
        private string returnedValue;
        private ICalculatorServiceAsyncAPM proxyAPM;
        private ICalculatorServiceAsyncTAP proxyTAP;
        private object proxy;

        public CalculatorProxyAsync()
        {
            returnedValue = "not yet";
            string address = "http://localhost:9003/CalculatorService";
            Uri addressBase = new Uri(address);
            EndpointAddress endpoint = new EndpointAddress(address);
            BasicHttpBinding bHttp = new BasicHttpBinding();
            ChannelFactory<T> channel = new ChannelFactory<T>(bHttp, endpoint);
            proxy = channel.CreateChannel(endpoint);
            
            if ((proxy as ICalculatorServiceAsyncAPM) != null)
            {
                proxyAPM = (channel.CreateChannel(endpoint) as ICalculatorServiceAsyncAPM);
            }
            if ((proxy as ICalculatorServiceAsyncTAP) != null)
            {
                proxyTAP = (channel.CreateChannel(endpoint) as ICalculatorServiceAsyncTAP);
            }
        }

        public async Task<string> GetSum(int a, int b)
        {
            if ((proxy as ICalculatorServiceAsyncAPM) != null)
            {
                proxyAPM.BeginGetSum(a, b, Callback, proxyAPM);
                while(returnedValue.Equals("not yet"))
                {
                    await Task.Delay(10);
                }
                return await Task.Factory.StartNew(() => returnedValue);
            }

            if ((proxy as ICalculatorServiceAsyncTAP) != null)
            {
                return await (proxy as ICalculatorServiceAsyncTAP)?.GetSum(a, b);
            }

            return await Task.Factory.StartNew(() => "666");
        }

        private void Callback(IAsyncResult result)
        {
            var res = result.AsyncState as ICalculatorServiceAsyncAPM;
            if (res != null)
            {
                returnedValue = res.EndGetSum(result);
            }
        }

    }
}

using MobileWCF.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobileWCF.Proxies
{
    public class CalculatorProxyAsync<T> : ICalculatorProxy
    {
        private string returnedValue;
        private object proxy;
        private readonly ManualResetEvent waitForIt = new ManualResetEvent(false);

        public CalculatorProxyAsync()
        {
            returnedValue = "not yet";
            string address = "http://192.168.106.164:9003/CalculatorService";
            Uri addressBase = new Uri(address);
            EndpointAddress endpoint = new EndpointAddress(address);
            BasicHttpBinding bHttp = new BasicHttpBinding();
            ChannelFactory<T> channel = new ChannelFactory<T>(bHttp, endpoint);
            proxy = channel.CreateChannel(endpoint);
        }

        public async Task<string> GetSum(int a, int b)
        {
            if ((proxy as ICalculatorServiceAsyncAPM) != null)
            {
                Task<string> getDataTask = 
                    new TaskFactory().FromAsync((proxy as ICalculatorServiceAsyncAPM).BeginGetSum, 
                                                (proxy as ICalculatorServiceAsyncAPM).EndGetSum, 
                                                a,
                                                b, 
                                                null, 
                                                TaskCreationOptions.None);
                return await getDataTask;
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
                waitForIt.Set();
            }
        }

    }
}

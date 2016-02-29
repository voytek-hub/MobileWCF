using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MobileWCF.Contracts
{
    [ServiceContract(Name = "ICalculatorServiceAsyncAPM")]
    public interface ICalculatorServiceAsyncAPM
    {
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetSum(int a, int b, AsyncCallback callback, object state = null);
        string EndGetSum(IAsyncResult asyncResult);
    }

    [ServiceContract(Name = "ICalculatorServiceAsyncTAP")]
    public interface ICalculatorServiceAsyncTAP
    {
        [OperationContract]
        Task<string> GetSum(int a, int b);
    }

    [ServiceContract(Name = "ICalculatorServiceSync")]
    public interface ICalculatorServiceSync
    {
        [OperationContract]
        string GetSum(int a, int b);
    }
}

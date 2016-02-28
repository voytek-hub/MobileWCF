using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace MobileWCF.Contracts
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginGetSum(int a, int b, AsyncCallback callback, object state);
        string EndGetSum(IAsyncResult asyncResult);
    }
}

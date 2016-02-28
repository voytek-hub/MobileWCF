using MobileWCF.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWCF.ServerHost
{
    public class CalculatorServiceAsyncAPM : CalculatorServiceAsyncTAP, ICalculatorServiceAsyncAPM
    {
        public IAsyncResult BeginGetSum(int a, int b, AsyncCallback callback, object state)
        {
            var tcs = new TaskCompletionSource<string>(state);
            var task = GetSum(a, b);
            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                    tcs.TrySetException(t.Exception.InnerExceptions);
                else if (t.IsCanceled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult(t.Result);

                if (callback != null)
                    callback(tcs.Task);
            });
            return tcs.Task;
        }

        public string EndGetSum(IAsyncResult asyncResult)
        {
            try
            {
                return ((Task<string>)asyncResult).Result;
            }
            catch (AggregateException ex)
            {
                throw ex.InnerException;
            }
        }
    }

    public class CalculatorServiceAsyncTAP : CalculatorServiceSync, ICalculatorServiceAsyncTAP
    {
        public new Task<string> GetSum(int a, int b)
        {
            return Task.Factory.StartNew(() => base.GetSum(a, b));
        }
    }

    public class CalculatorServiceSync : ICalculatorServiceSync
    {
        public string GetSum(int a, int b)
        {
            return ((long)a + b).ToString();
        }
    }
}

using MobileWCF.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWCF.Domain
{
    public class Calculator
    {
        private readonly ICalculatorServiceAsyncTAP proxy;

        public Calculator(ICalculatorServiceAsyncTAP proxy)
        {
            this.proxy = proxy;
        }

        public async Task<string> Add(int a, int b)
        {
            return await proxy.GetSum(a, b);
        }
    }
}

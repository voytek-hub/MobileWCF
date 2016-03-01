using System.Threading.Tasks;
using MobileWCF.Domain.Interfaces;

namespace MobileWCF.Domain
{
    public class Calculator
    {
        private readonly ICalculatorProxy proxy;

        public Calculator(ICalculatorProxy proxy)
        {
            this.proxy = proxy;
        }

        public async Task<string> Add(int a, int b)
        {
            return await proxy.GetSum(a, b);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWCF.Proxies
{
    public interface ICalculatorProxy
    {
        Task<string> GetSum(int a, int b);
    }
}

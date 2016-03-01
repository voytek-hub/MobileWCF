using System.Threading.Tasks;

namespace MobileWCF.Domain.Interfaces
{
    public interface ICalculatorProxy
    {
        Task<string> GetSum(int a, int b);
    }
}

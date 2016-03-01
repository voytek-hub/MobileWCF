using MobileWCF.Contracts;
using MobileWCF.Domain;
using MobileWCF.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileWCF.WinClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ICalculatorProxy proxy = new CalculatorProxyAsync<ICalculatorServiceAsyncAPM>();
            Calculator calculatorApi = new Calculator(proxy);
            Application.Run(new MainForm(calculatorApi));
        }
    }
}

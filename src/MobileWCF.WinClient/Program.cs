using MobileWCF.Domain;
using MobileWCF.Domain.Interfaces;
using MobileWCF.Proxies;
using System;
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

            ICalculatorProxy proxy = new CalculatorProxy();
            Calculator calculatorApi = new Calculator(proxy);
            Application.Run(new MainForm(calculatorApi));
        }
    }
}

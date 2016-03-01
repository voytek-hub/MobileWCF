using System;
using System.Windows.Forms;
using MobileWCF.Domain;

namespace MobileWCF.WinClient
{
    public partial class MainForm : Form
    {
        private readonly Calculator calculatorDomain;

        public MainForm(Calculator calculator = null)
        {
            InitializeComponent();
            calculatorDomain = calculator;
        }

        private async void bAddAsyncTAP_Click(object sender, EventArgs e)
        {
            if (calculatorDomain == null)
                throw new ArgumentNullException("calculatorDomain");

            var num1 = Convert.ToInt32(tbNum1.Text);
            var num2 = Convert.ToInt32(tbNum2.Text);
            lResult.Text = await calculatorDomain?.Add(num1, num2);
        }
    }
}

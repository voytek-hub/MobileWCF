using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using MobileWCF.Contracts;
using System.Diagnostics;

namespace MobileWCF.WinClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string strAddress = "http://localhost:9003/CalculatorService";
            BasicHttpBinding httpBinding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress(strAddress);
            ChannelFactory<ICalculatorService> channel = new ChannelFactory<ICalculatorService>(httpBinding, address);
            var calculator = channel.CreateChannel(address);
            var num1 = Convert.ToInt32(tbNum1.Text);
            var num2 = Convert.ToInt32(tbNum2.Text);
            var num = calculator.BeginGetSum(num1, num2, Callback, calculator);
        }

        private void Callback(IAsyncResult result)
        {
            var res = result.AsyncState as ICalculatorService;
            if (res != null)
            {
                Task.Run(() => res.EndGetSum(result))
                    .ContinueWith(t => lResult.Text = t.Result, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
    }
}

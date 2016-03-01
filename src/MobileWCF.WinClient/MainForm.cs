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
using MobileWCF.Domain;

namespace MobileWCF.WinClient
{
    public partial class MainForm : Form
    {
        private readonly Calculator calculatorDomain;
        private readonly string strAddress = "http://192.168.106.164:9003/CalculatorService";

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(Calculator calculator)
        {
            InitializeComponent();
            calculatorDomain = calculator;
        }

        private void bAddAsyncAPM_Click(object sender, EventArgs e)
        {
            BasicHttpBinding httpBinding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress(strAddress);
            ChannelFactory<ICalculatorServiceAsyncAPM> channel = new ChannelFactory<ICalculatorServiceAsyncAPM>(httpBinding, address);
            var calculator = channel.CreateChannel(address);
            var num1 = Convert.ToInt32(tbNum1.Text);
            var num2 = Convert.ToInt32(tbNum2.Text);
            var num = calculator.BeginGetSum(num1, num2, Callback, calculator);
        }

        private void Callback(IAsyncResult result)
        {
            var res = result.AsyncState as ICalculatorServiceAsyncAPM;
            if (res != null)
            {
                Task.Run(() => res.EndGetSum(result))
                    .ContinueWith(t => lResult.Text = t.Result, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private async void bAddAsyncTAP_Click(object sender, EventArgs e)
        {
            //BasicHttpBinding httpBinding = new BasicHttpBinding();
            //EndpointAddress address = new EndpointAddress(strAddress);
            //ChannelFactory<ICalculatorServiceAsyncTAP> channel = new ChannelFactory<ICalculatorServiceAsyncTAP>(httpBinding, address);
            //var calculator = channel.CreateChannel(address);
            //var num1 = Convert.ToInt32(tbNum1.Text);
            //var num2 = Convert.ToInt32(tbNum2.Text);
            //lResult.Text = await calculator.GetSum(num1, num2);

            var num1 = Convert.ToInt32(tbNum1.Text);
            var num2 = Convert.ToInt32(tbNum2.Text);
            lResult.Text = await calculatorDomain.Add(num1, num2);
        }

        private void bAddSync_Click(object sender, EventArgs e)
        {
            BasicHttpBinding httpBinding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress(strAddress);
            ChannelFactory<ICalculatorServiceSync> channel = new ChannelFactory<ICalculatorServiceSync>(httpBinding, address);
            var calculator = channel.CreateChannel(address);
            var num1 = Convert.ToInt32(tbNum1.Text);
            var num2 = Convert.ToInt32(tbNum2.Text);
            lResult.Text = calculator.GetSum(num1, num2);
        }
    }
}

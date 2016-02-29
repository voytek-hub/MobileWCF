using MobileWCF.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;

namespace MobileWCF.Mobile.Views
{
    public partial class FirstPage : ContentPage
    {
        ICalculatorServiceAsyncAPM proxyAPM;
        public FirstPage()
        {
            InitializeComponent();
            b1.Clicked += OnButtonClicked;
        }

        public FirstPage(ICalculatorServiceAsyncAPM proxy)
        {
            InitializeComponent();
            b1.Clicked += OnButtonClicked;
            proxyAPM = proxy;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Clicked");
            try
            {
                //string strAddress = "http://localhost:9003/CalculatorService";
                //BasicHttpBinding httpBinding = new BasicHttpBinding();
                //EndpointAddress address = new EndpointAddress(strAddress);

                //ChannelFactory<ICalculatorServiceAsyncAPM> channel = 
                //    new ChannelFactory<ICalculatorServiceAsyncAPM>(httpBinding, address);

                //var calculator = channel.CreateChannel(address);

                var num1 = Convert.ToInt32(eNum1.Text);
                var num2 = Convert.ToInt32(eNum2.Text);
                proxyAPM.BeginGetSum(num1, num2, Callback);
            }
            catch (Exception ex)
            {
                lResult.Text = ex.Message;
                Debug.WriteLine(ex);
            }
        }

        private void Callback(IAsyncResult result)
        {
            var msg = "";
            var res = result.AsyncState as ICalculatorServiceAsyncAPM;
            if (res != null)
                msg = res.EndGetSum(result);

            Device.BeginInvokeOnMainThread(() => lResult.Text = msg);
        }
    }
}

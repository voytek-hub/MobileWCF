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
using MobileWCF.Domain;

namespace MobileWCF.Mobile.Views
{
    public partial class FirstPage : ContentPage
    {
        private readonly Calculator calculatorDomain;

        public FirstPage()
        {
            InitializeComponent();
            b1.Clicked += OnButtonClicked;
        }

        public FirstPage(Calculator calculator)
        {
            InitializeComponent();
            b1.Clicked += OnButtonClicked;
            calculatorDomain = calculator;
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Clicked");
            try
            {
                var num1 = Convert.ToInt32(eNum1.Text);
                var num2 = Convert.ToInt32(eNum2.Text);

                var msg = "None";
                msg = await calculatorDomain?.Add(num1, num2);

                Device.BeginInvokeOnMainThread(() => lResult.Text = msg);
            }
            catch (Exception ex)
            {
                lResult.Text = ex.Message;
                Debug.WriteLine(ex);
            }
        }
    }
}

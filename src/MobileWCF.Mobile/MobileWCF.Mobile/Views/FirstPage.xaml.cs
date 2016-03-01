using System;
using System.Diagnostics;
using Xamarin.Forms;
using MobileWCF.Domain;

namespace MobileWCF.Mobile.Views
{
    public partial class FirstPage : ContentPage
    {
        private readonly Calculator calculatorDomain;

        public FirstPage(Calculator calculator = null)
        {
            InitializeComponent();
            b1.Clicked += OnButtonClicked;
            calculatorDomain = calculator;
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Button clicked");

            if (calculatorDomain == null)
                throw new ArgumentNullException("calculatorDomain");

            try
            {
                var num1 = Convert.ToInt32(eNum1.Text);
                var num2 = Convert.ToInt32(eNum2.Text);
                var msg = await calculatorDomain?.Add(num1, num2);

                Device.BeginInvokeOnMainThread(() => lResult.Text = msg);
            }
            catch (Exception ex)
            {
                lResult.Text = "Exception: " + ex.Message;
                Debug.WriteLine("--- Exception ------------------------------------------");
                Debug.WriteLine(ex);
                Debug.WriteLine("--------------------------------------------------------");
            }
        }
    }
}

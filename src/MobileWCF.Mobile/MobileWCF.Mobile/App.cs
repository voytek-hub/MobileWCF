using MobileWCF.Contracts;
using MobileWCF.Domain;
using MobileWCF.Mobile.Views;
using MobileWCF.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MobileWCF.Mobile
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            ICalculatorProxy proxy = new CalculatorProxyAsync<ICalculatorServiceAsyncAPM>();
            Calculator calculatorApi = new Calculator(proxy);
            MainPage = new FirstPage(calculatorApi);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

using MobileWCF.Domain;
using MobileWCF.Domain.Interfaces;
using MobileWCF.Mobile.Views;
using MobileWCF.Proxies;
using Xamarin.Forms;

namespace MobileWCF.Mobile
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            ICalculatorProxy proxy = new CalculatorProxy();
            Calculator calculator = new Calculator(proxy);
            MainPage = new FirstPage(calculator);
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

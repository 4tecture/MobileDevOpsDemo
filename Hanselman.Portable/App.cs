using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Hanselman.Portable.Views;
using Hanselman.Portable.Auth;

namespace Hanselman.Portable
{
    public class App : Application, ILoginManager
    {
        public static bool IsWindows10 {get;set;}
        public static IAuthenticate Authenticator { get; private set; }

        public App()
        {
            // The root page of your application
            MainPage = new LoginPage(this);
        }

        

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }

        protected override void OnResume()
        {
            if (Authenticator.IsAuthenticated)
            {
                this.ShowMainPage();
            }
            else
            {
                this.ShowLogin();
            }
        }

        public void ShowMainPage()
        {
            MainPage = new RootPage();
        }

        public void ShowLogin()
        {
            MainPage = new LoginPage(this);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        
    }
}

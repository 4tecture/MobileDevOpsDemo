using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Content.PM;
using Hanselman.Portable;
using Android.Graphics.Drawables;
using ImageCircle.Forms.Plugin.Droid;
using HockeyApp.Android.Metrics;
using HockeyApp.Android;
using Hanselman.Portable.Helpers;
using HanselmanAndroid.Helpers;
using Microsoft.WindowsAzure.MobileServices;
using Hanselman.Portable.Auth;
using System.Threading.Tasks;

namespace HanselmanAndroid
{
    [Activity(Label = "Hanselman",
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity, IAuthenticate
    {
        private MobileServiceUser user;
        public bool IsAuthenticated { get; private set; }


        protected override void OnCreate(Bundle bundle)
        {


            // void TrackEvent(string name, IDictionary<string, string> properties = null, IDictionary<string, double> measurements = null)
            CrashManager.Register(this);
            MetricsManager.Register(Application);
            FeedbackManager.Register(Application);
            

            //FeedbackManager.ShowFeedbackActivity(ApplicationContext); // todo: demo only
            //DependencyService.Register<IFeedbackService, FeedbackService>(); // using DependencyAttribute

            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;
            base.OnCreate(bundle);
            Forms.Init(this, bundle);
            ImageCircleRenderer.Init();
            App.Init(this);
            LoadApplication(new App());
        }

        protected override void OnResume()
        {
            base.OnResume();
            Tracking.StartUsage(this);
        }

        protected override void OnPause()
        {
            base.OnPause();
            Tracking.StopUsage(this);
        }

        public async Task<bool> Authenticate()
        {
            this.IsAuthenticated = false;
            var message = string.Empty;
            try
            {
                // Sign in with Facebook login using a server-managed flow.
                user = await ServiceClientManager.Instance.Client.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook);

                if (user != null)
                {
                    message = string.Format("you are now signed-in as {0}.", user.UserId);
                    this.IsAuthenticated = true;
                    
                }
            }
            catch (Exception ex)
            {
                // TODO: show error dialog
                message = ex.Message;
            }

            return this.IsAuthenticated;
        }
    }
}

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

namespace HanselmanAndroid
{
    [Activity(Label = "Hanselman",
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {

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
    }
}

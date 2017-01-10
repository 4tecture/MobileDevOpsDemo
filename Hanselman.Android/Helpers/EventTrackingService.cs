using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Hanselman.Portable.Helpers;
using HockeyApp;
using Xamarin.Forms;

[assembly: Dependency(typeof(HanselmanAndroid.Helpers.EventTrackingService))]
namespace HanselmanAndroid.Helpers
{
    public class EventTrackingService : IEventTrackingService
    {
        public void TrackEvent(string name, Dictionary<string, string> properties = null, Dictionary<string, double> measurements = null)
        {
            MetricsManager.TrackEvent(name, properties, measurements);
        }
    }
}
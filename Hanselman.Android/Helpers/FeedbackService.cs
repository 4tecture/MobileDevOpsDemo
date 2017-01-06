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
using Xamarin.Forms;
using HockeyApp.Android;

[assembly: Dependency(typeof(HanselmanAndroid.Helpers.FeedbackService))]
namespace HanselmanAndroid.Helpers
{
    public class FeedbackService : IFeedbackService
    {
        Context con = Forms.Context;
        public void ProvideFeedback()
        {
            FeedbackManager.ShowFeedbackActivity(con);
        }
    }
}
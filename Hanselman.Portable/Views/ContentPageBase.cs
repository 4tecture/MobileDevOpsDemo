using Hanselman.Portable.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hanselman.Portable.Views
{
    public class ContentPageBase : ContentPage
    {
        private IEventTrackingService eventTrackingService;
        private Stopwatch stopWatch;

        public ContentPageBase()
        {
            eventTrackingService = DependencyService.Get<IEventTrackingService>();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (eventTrackingService != null)
            {
                eventTrackingService.TrackEvent("PageView", new Dictionary<string, string>() { { "View", this.GetType().Name } });
            }
            stopWatch = Stopwatch.StartNew();

            var lifecycleEvent = this.BindingContext as IPageLifeCycleEvents;
            if(lifecycleEvent != null)
            {
                lifecycleEvent.OnAppearing();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (eventTrackingService != null && stopWatch != null)
            {
                stopWatch.Stop();
                eventTrackingService.TrackEvent("PageVisitDuration", new Dictionary<string, string> { { "View", this.GetType().Name } }, new Dictionary<string, double>() { {"Duration", stopWatch.ElapsedMilliseconds} });
            }

            var lifecycleEvent = this.BindingContext as IPageLifeCycleEvents;
            if (lifecycleEvent != null)
            {
                lifecycleEvent.OnDisappearing();
            }
        }
    }
}

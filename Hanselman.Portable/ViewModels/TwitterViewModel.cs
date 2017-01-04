using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using LinqToTwitter;
using System.Threading.Tasks;
using System.Linq;
using Hanselman.Portable.Manager;

namespace Hanselman.Portable
{
    public class TwitterViewModel : BaseViewModel
    {
        private IFeedManager<Tweet> twitterManager;
        public ObservableCollection<Tweet> Tweets { get; set; }

        public TwitterViewModel()
        {
            Title = "Twitter";
            Icon = "slideout.png";
            Tweets = new ObservableCollection<Tweet>();
            this.twitterManager = ManagerFactory.CreateTwitterManager(
                                    "ZTmEODUCChOhLXO4lnUCEbH2I",
                                    "Y8z2Wouc5ckFb1a0wjUDT9KAI6DUat5tFNdmIkPLl8T4Nyaa2J");
        }

        private Command loadTweetsCommand;

        public Command LoadTweetsCommand
        {
            get
            {
                return loadTweetsCommand ??
                  (loadTweetsCommand = new Command(async () =>
                  {
                      await ExecuteLoadTweetsCommand();
                  }, () =>
                  {
                      return !IsBusy;
                  }));
            }
        }

        public async Task ExecuteLoadTweetsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            LoadTweetsCommand.ChangeCanExecute();
            var error = false;
            try
            {
                Tweets.Clear();
                var tweets = await this.twitterManager.LoadItemsAsync();
                foreach (var tweet in tweets)
                {
                    Tweets.Add(tweet);
                }

                if (Device.OS == TargetPlatform.iOS)
                {
                    // only does anything on iOS, for the Watch
                    DependencyService.Get<ITweetStore>().Save(tweets.ToList());
                }



            }
            catch
            {
                error = true;
            }

            if (error)
            {
                var page = new ContentPage();
                await page.DisplayAlert("Error", "Unable to load tweets.", "OK");
            }

            IsBusy = false;
            LoadTweetsCommand.ChangeCanExecute();
        }
    }
}


using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanselman.Portable.Manager
{
    public class TwitterManager : IFeedManager<Tweet>
    {
        private IAuthorizer auth;

        public TwitterManager(string consumerKey, string consumerSecret)
        {
            this.auth = new ApplicationOnlyAuthorizer()
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = "ZTmEODUCChOhLXO4lnUCEbH2I",
                    ConsumerSecret = "Y8z2Wouc5ckFb1a0wjUDT9KAI6DUat5tFNdmIkPLl8T4Nyaa2J",
                },
            };
        }

        public async Task<IEnumerable<Tweet>> LoadItemsAsync(string search = null)
        {

            await auth.AuthorizeAsync();

            var twitterContext = new TwitterContext(auth);

            var query = from tweet in twitterContext.Status
                        where tweet.Type == StatusType.User &&
                                tweet.ScreenName == "shanselman" &&
                                tweet.Count == 100 &&
                                tweet.IncludeRetweets == true &&
                                tweet.ExcludeReplies == true &&
                                (string.IsNullOrWhiteSpace(search) || tweet.Text.Contains(search))
                        select tweet;

            var queryResponse = await query.ToListAsync();

            return (from tweet in queryResponse
                    select new Tweet
                    {
                        StatusID = tweet.StatusID,
                        ScreenName = tweet.User.ScreenNameResponse,
                        Text = tweet.Text,
                        CurrentUserRetweet = tweet.CurrentUserRetweet,
                        CreatedAt = tweet.CreatedAt,
                        Image = tweet.RetweetedStatus != null && tweet.RetweetedStatus.User != null
                                    ? tweet.RetweetedStatus.User.ProfileImageUrl.Replace("http://", "https://")
                                    : (tweet.User.ScreenNameResponse == "shanselman"
                                        ? "scott159.png"
                                        : tweet.User.ProfileImageUrl.Replace("http://", "https://"))
                    }).ToList();
        }
    }
}

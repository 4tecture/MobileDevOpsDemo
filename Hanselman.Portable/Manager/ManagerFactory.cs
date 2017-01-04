using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanselman.Portable.Manager
{
    public static class ManagerFactory
    {
        public static bool IsMocked { get; set; } = false;

        public static IFeedManager<Tweet> CreateTwitterManager(string consumerKey, string consumerSecret)
        {
            return IsMocked
                ? new MockTwitterManager() as IFeedManager<Tweet>
                : new TwitterManager(consumerKey, consumerSecret);
        }
    }
}

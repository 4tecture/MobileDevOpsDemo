using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanselman.Portable.Manager
{
    public class MockTwitterManager : IFeedManager<Tweet>
    {
        public async Task<IEnumerable<Tweet>> LoadItemsAsync(string search = null)
        {
            await Task.Delay(2000);

            var items = new[] {
            new Tweet() { Text = "Tweet1" },
            new Tweet() { Text = "Tweet2" },
            new Tweet() { Text = "Tweet3" },
            new Tweet() { Text = "Tweet4" },
            // required for test
            new Tweet() { Text = "#shanselman" }
        };

            if (!string.IsNullOrWhiteSpace(search))
            {
                items = items.Where(i => i.Text.Contains(search)).ToArray();
            }

            return items;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanselman.Portable.Manager
{
    public interface IFeedManager<T>
    {
        Task<IEnumerable<T>> LoadItemsAsync(string search = null);
    }
}

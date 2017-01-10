using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanselman.Portable.Helpers
{
    public interface IPageLifeCycleEvents
    {
        void OnAppearing();
        void OnDisappearing();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanselman.Portable.Helpers
{
    public interface IEventTrackingService
    {
        void TrackEvent(string name, Dictionary<string, string> properties = null, Dictionary<string, double> measurements = null);
    }
}

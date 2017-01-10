using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanselman.Portable.Auth
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate();

        bool IsAuthenticated { get; }
    }
}

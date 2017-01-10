using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanselman.Portable.Auth
{
    public interface ILoginManager
    {
        void ShowMainPage();

        void ShowLogin();
    }
}

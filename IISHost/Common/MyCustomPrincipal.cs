using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IISHost.Common
{
    public class MyCustomPrincipal : IPrincipal
    {
        IIdentity _identity;
        string[] _roles;

        public MyCustomPrincipal(IIdentity identity)
        {
            _identity = identity;
        }

        // helper method for easy access (without casting)
        public static MyCustomPrincipal Current
        {
            get
            {
                return Thread.CurrentPrincipal as MyCustomPrincipal;
            }
        }

        public IIdentity Identity
        {
            get
            {
                return _identity;
            }
        }

        public bool IsInRole(string role)
        {
            if (Identity.Name == "a")
            {
                role = "ADMIN";                
            }
            else
            {
                role = "USER";
            }
            return role.Contains(role);
        }
    }
}

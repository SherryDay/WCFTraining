using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.ServiceModel.Description;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Principal;

namespace IISHost.Common
{
    public class MyCustomValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if ((userName != "h" || (password != "p")))
            {
                throw new SecurityTokenException("Validation Failed!");
            }
            //Console.WriteLine(DateTime.Now.ToString() + "Validation success for user :" + userName);
        }
    }
}

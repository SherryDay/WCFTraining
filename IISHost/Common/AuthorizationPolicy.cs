using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Policy;
using System.IdentityModel.Claims;
using System.Security.Principal;

namespace IISHost.Common
{
    public class AuthorizationPolicy : IAuthorizationPolicy
    {
        Guid _id = Guid.NewGuid();

        public ClaimSet Issuer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            IIdentity client = GetClientIdentity(evaluationContext);

            evaluationContext.Properties["Principal"] = new MyCustomPrincipal(client);

            return true;
        }

        public IIdentity GetClientIdentity(EvaluationContext evaluationContext)
        {
            object obj;
            if (!evaluationContext.Properties.TryGetValue("Identities", out obj))
                throw new Exception("No Identity Found!");
            IList<IIdentity> identities = obj as IList<IIdentity>;
            if (identities == null || identities.Count <=0)
            {
                throw new Exception("No Identity Found!");
            }
            return identities[0];
        }
    }
}

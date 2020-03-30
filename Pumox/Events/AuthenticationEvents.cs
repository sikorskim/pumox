using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ZNetCS.AspNetCore.Authentication.Basic.Events;

namespace Pumox.Events
{
    public class AuthenticationEvents : BasicAuthenticationEvents
    {
        private readonly string demoUsername = "uszer";
        private readonly string demoPassword = "Paszwort123";
        public override Task ValidatePrincipalAsync(ValidatePrincipalContext context)
        {

            if ((context.UserName == demoUsername) && (context.Password == demoPassword))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, context.UserName, context.Options.ClaimsIssuer)
            };

                var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, context.Scheme.Name));
                context.Principal = principal;
            }

            return Task.CompletedTask;
        }
    }
}

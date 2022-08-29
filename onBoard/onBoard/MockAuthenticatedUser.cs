﻿using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace onBoard
{
    public class MockAuthenticatedUser : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        const string userId = "ppp";
        const string userName = "El Chema";
        const string userRole = "ProductManager";

        public MockAuthenticatedUser(
          IOptionsMonitor<AuthenticationSchemeOptions> options,
          ILoggerFactory logger,
          UrlEncoder encoder,
          ISystemClock clock)
          : base(options, logger, encoder, clock) { }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var claims = new[]
              {
          new Claim(ClaimTypes.NameIdentifier, userId),
          new Claim(ClaimTypes.Name, userName),
          new Claim(ClaimTypes.Role, userRole),
          new Claim(ClaimTypes.Email, "hello@you.com"),
        };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return await Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
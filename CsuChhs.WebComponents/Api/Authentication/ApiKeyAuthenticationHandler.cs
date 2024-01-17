using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CsuChhs.WebComponents.Api.Authentication
{
    /// <summary>
    /// This class handles the authentication for an API key based
    /// auth for web APIs.  It requires the user to pass in a valid API key
    /// to the X-CHHS-API-KEY header.
    ///
    /// API keys are defined by implementing the IApiKeyStore interface
    /// somewhere in your consuming project and injecting it with
    /// a singleton into the DI container.
    ///
    /// You can either add this authentication as the default,
    /// or you can specify it in the [Authorize] for each class/method.
    ///
    /// Please see the DevHub project for implementation details.
    /// </summary>
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        private readonly IApiKeyStore _apiKeyStore;
        private const string ApiKeyHeaderName = "X-CHHS-API-KEY";

        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<ApiKeyAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IApiKeyStore apiKeyStore) : base(options, logger, encoder, clock)
        {
            _apiKeyStore = apiKeyStore;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKeyHeaderValues))
            {
                return AuthenticateResult.NoResult();
            }

            var providedApiKey = apiKeyHeaderValues.FirstOrDefault();

            if (apiKeyHeaderValues.Count == 0 || string.IsNullOrWhiteSpace(providedApiKey))
            {
                return AuthenticateResult.NoResult();
            }

            if (providedApiKey == _apiKeyStore.GetKey())
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "CHHS App"),
                    new Claim("API Read", "1", ClaimValueTypes.String)
                };

                var identity = new ClaimsIdentity(claims, Options.AuthenticationType);
                var identities = new List<ClaimsIdentity> { identity };
                var principal = new ClaimsPrincipal(identities);
                var ticket = new AuthenticationTicket(principal, Options.Scheme);

                return AuthenticateResult.Success(ticket);
            }

            if (!string.IsNullOrEmpty(_apiKeyStore.GetWriteKey()) && providedApiKey == _apiKeyStore.GetWriteKey())
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "CHHS App"),
                    new Claim("API Write", "1", ClaimValueTypes.String),
                    new Claim("API Read", "1", ClaimValueTypes.String)
                };

                var identity = new ClaimsIdentity(claims, Options.AuthenticationType);
                var identities = new List<ClaimsIdentity> { identity };
                var principal = new ClaimsPrincipal(identities);
                var ticket = new AuthenticationTicket(principal, Options.Scheme);

                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("Invalid API Key Provided");
        }
    }
}

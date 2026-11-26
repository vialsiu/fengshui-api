//------checks the X-Api-Key header on every request and works out who's calling
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using FengShui.Api.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace FengShui.Api.Auth;

/// <summary>
/// logs a request in from its api key, the admin key from config or a player's key from the database
/// </summary>
/// <param name="options">scheme options</param>
/// <param name="logger">logging</param>
/// <param name="encoder">url encoder the base class needs</param>
/// <param name="players">where player keys are looked up</param>
/// <param name="configuration">where the admin key is kept</param>
//----ref https://learn.microsoft.com/en-us/aspnet/core/security/authentication/
//--ref https://www.c-sharpcorner.com/article/securing-asp-net-core-apis-with-api-keys
public class ApiKeyAuthenticationHandler(
    IOptionsMonitor<AuthenticationSchemeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder,
    IPlayerRepository players,
    IConfiguration configuration)
    : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    /// <summary>
    /// reads the key and turns it into a logged in user with a role
    /// </summary>
    /// <returns>success, no key at all, or a failure for a key nobody owns</returns>
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        //-------no header just means not logged in, [Authorize] decides if that's a problem
        if (!Request.Headers.TryGetValue(ApiKeyDefaults.HeaderName, out var values))
            return AuthenticateResult.NoResult();

        var key = values.ToString();
        if (string.IsNullOrWhiteSpace(key))
            return AuthenticateResult.NoResult();

        List<Claim> claims;
        if (IsAdminKey(key))
        {
            claims =
            [
                new Claim(ClaimTypes.Name, "admin"),
                new Claim(ClaimTypes.Role, ApiKeyDefaults.AdminRole)
            ];
        }
        else
        {
            var player = await players.GetByApiKeyAsync(key);
            if (player == null)
                return AuthenticateResult.Fail("that api key doesn't belong to anyone");

            //---the player's id goes in NameIdentifier so controllers can tell whose layouts are whose
            claims =
            [
                new Claim(ClaimTypes.NameIdentifier, player.Id.ToString()),
                new Claim(ClaimTypes.Name, player.Name),
                new Claim(ClaimTypes.Role, ApiKeyDefaults.PlayerRole)
            ];
        }

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), Scheme.Name);
        return AuthenticateResult.Success(ticket);
    }

    //-----compares in constant time so nobody can guess the admin key from how long the check takes
    //------ref https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.cryptographicoperations.fixedtimeequals
    private bool IsAdminKey(string key)
    {
        var adminKey = configuration["Auth:AdminKey"];
        if (string.IsNullOrEmpty(adminKey))
            return false;

        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(key),
            Encoding.UTF8.GetBytes(adminKey));
    }
}

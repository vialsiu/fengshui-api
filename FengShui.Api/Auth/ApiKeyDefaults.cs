//---names used by the api key login, kept in one place so nothing is spelt two ways
namespace FengShui.Api.Auth;

/// <summary>
///---- the header, scheme and role names for api key auth
/// </summary>
public static class ApiKeyDefaults
{
    /// <summary>name of the auth scheme</summary>
    public const string SchemeName = "ApiKey";
    /// <summary>header the key is sent in</summary>
    public const string HeaderName = "X-Api-Key";
    /// <summary>role for the admin key, can change the game's content</summary>
    public const string AdminRole = "Admin";
    /// <summary>role for a player's key</summary>
    public const string PlayerRole = "Player";
}
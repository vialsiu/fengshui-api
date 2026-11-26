//-----makes new player api keys, random enough that nobody can guess one
using System.Security.Cryptography;

namespace FengShui.Api.Auth;

/// <summary>
/// makes api keys for new players
/// </summary>
public static class ApiKeyGenerator
{
    //---32 random bytes = 64 hex characters, the fs_ at the front just makes it easy to spot
    private const int KeyBytes = 32;
    private const string Prefix = "fs_";

    /// <summary>
    /// a brand new random api key
    /// </summary>
    /// <returns>the key, like fs_3f9a...</returns>
    //------ref https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.randomnumbergenerator
    public static string NewKey()
    {
        var bytes = RandomNumberGenerator.GetBytes(KeyBytes);
        return Prefix + Convert.ToHexString(bytes).ToLowerInvariant();
    }
}
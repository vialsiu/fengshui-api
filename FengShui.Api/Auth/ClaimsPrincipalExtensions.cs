//--------small helper so controllers can just write User.GetPlayerId()
using System.Security.Claims;

namespace FengShui.Api.Auth;

/// <summary>
///----- helpers for reading the logged in user
/// </summary>
public static class ClaimsPrincipalExtensions
{
    /// <summary>
    ///----- the id of the player who sent the request
    /// </summary>
    /// <param name="user">the logged in user</param>
    /// <returns>their player id, or null for the admin or nobody</returns>
    //---ref https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
    public static int? GetPlayerId(this ClaimsPrincipal user)
    {
        var value = user.FindFirstValue(ClaimTypes.NameIdentifier);
        return int.TryParse(value, out var id) ? id : null;
    }

    /// <summary>
    ///---- true if the request used the admin key
    /// </summary>
    /// <param name="user">the logged in user</param>
    /// <returns>whether they're the admin</returns>
    public static bool IsAdmin(this ClaimsPrincipal user)
    {
        return user.IsInRole(ApiKeyDefaults.AdminRole);
    }
}
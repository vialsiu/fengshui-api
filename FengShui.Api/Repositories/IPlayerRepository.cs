//--players are found by the api key they send in the X-Api-Key header
using FengShui.Api.Models;

namespace FengShui.Api.Repositories;

/// <summary>
///---- storage for players
/// </summary>
public interface IPlayerRepository : IRepository<Player>
{
    /// <summary>
    ///--- the player who owns an api key
    /// </summary>
    /// <param name="apiKey">the key from the header</param>
    /// <returns>the player, or null if the key isn't anyone's</returns>
    Task<Player?> GetByApiKeyAsync(string apiKey);
}
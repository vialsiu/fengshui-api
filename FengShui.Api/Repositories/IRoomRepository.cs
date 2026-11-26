//--------rooms, a player sees the game's rooms plus the ones they made
using FengShui.Api.Models;

namespace FengShui.Api.Repositories;

/// <summary>
///---- storage for rooms
/// </summary>
public interface IRoomRepository : IRepository<Room>
{
    /// <summary>
    ///--- the rooms a player can see
    /// </summary>
    /// <param name="playerId">the player asking</param>
    /// <param name="mineOnly">true for only the rooms they made</param>
    /// <returns>the rooms</returns>
    Task<List<Room>> GetVisibleToAsync(int playerId, bool mineOnly);
}
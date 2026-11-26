//-------layouts come back with every piece and its furniture type
using FengShui.Api.Models;

namespace FengShui.Api.Repositories;

/// <summary>
///---- storage for layouts and their placements
/// </summary>
public interface ILayoutRepository : IRepository<Layout>
{
    /// <summary>
    ///--- every layout a player saved, newest first
    /// </summary>
    /// <param name="playerId">the player</param>
    /// <returns>their layouts with the pieces loaded</returns>
    Task<List<Layout>> GetForPlayerAsync(int playerId);

    /// <summary>
    ///---- one layout with its pieces, room and request loaded
    /// </summary>
    /// <param name="id">layout id</param>
    /// <returns>the layout, or null if there isn't one</returns>
    Task<Layout?> GetWithPlacementsAsync(int id);
}
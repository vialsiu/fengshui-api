//---rooms in sqlite, the game's rooms have no player id
using FengShui.Api.Data;
using FengShui.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FengShui.Api.Repositories;

/// <summary>
///---- ef core storage for rooms
/// </summary>
/// <param name="context">the database</param>
public class EfRoomRepository(FengShuiContext context)
    : EfRepository<Room>(context), IRoomRepository
{
    /// <inheritdoc />
    public async Task<List<Room>> GetVisibleToAsync(int playerId, bool mineOnly)
    {
        var query = mineOnly
            ? Set.Where(r => r.PlayerId == playerId)
            : Set.Where(r => r.PlayerId == null || r.PlayerId == playerId);
        return await query.OrderBy(r => r.Id).ToListAsync();
    }
}
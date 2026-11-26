//-------layouts in sqlite with every piece and what kind of furniture it is
using FengShui.Api.Data;
using FengShui.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FengShui.Api.Repositories;

/// <summary>
///--- ef core storage for layouts and their placements
/// </summary>
/// <param name="context">the database</param>
public class EfLayoutRepository(FengShuiContext context)
    : EfRepository<Layout>(context), ILayoutRepository
{
    /// <inheritdoc />
    public async Task<List<Layout>> GetForPlayerAsync(int playerId)
    {
        return await Set
            .Where(l => l.PlayerId == playerId)
            .Include(l => l.Placements!)
            .ThenInclude(p => p.FurnitureType)
            .OrderByDescending(l => l.UpdatedAt)
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Layout?> GetWithPlacementsAsync(int id)
    {
        return await Set
            .Include(l => l.Room)
            .Include(l => l.Request)
            .Include(l => l.Placements!)
            .ThenInclude(p => p.FurnitureType)
            .FirstOrDefaultAsync(l => l.Id == id);
    }
}
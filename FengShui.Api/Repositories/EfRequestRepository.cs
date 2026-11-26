//-----requests in sqlite with the client, room and inventory loaded in one go
using FengShui.Api.Data;
using FengShui.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FengShui.Api.Repositories;

/// <summary>
///---- ef core storage for requests and their furniture inventories
/// </summary>
/// <param name="context">the database</param>
public class EfRequestRepository(FengShuiContext context)
    : EfRepository<Request>(context), IRequestRepository
{
    //-------one place for the includes so both queries load the same things
    //--ref https://learn.microsoft.com/en-us/ef/core/querying/related-data/eager
    private IQueryable<Request> WithDetails()
    {
        return Set
            .Include(r => r.Client)
            .Include(r => r.Room)
            .Include(r => r.Inventory!)
            .ThenInclude(i => i.FurnitureType);
    }

    /// <inheritdoc />
    public async Task<List<Request>> GetAllWithDetailsAsync()
    {
        return await WithDetails().OrderBy(r => r.Id).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Request?> GetWithDetailsAsync(int id)
    {
        return await WithDetails().FirstOrDefaultAsync(r => r.Id == id);
    }

    /// <inheritdoc />
    public async Task<Layout?> GetStartLayoutAsync(int requestId)
    {
        return await Context.Layouts
            .Include(l => l.Placements!)
            .ThenInclude(p => p.FurnitureType)
            .FirstOrDefaultAsync(l => l.RequestId == requestId && l.Kind == LayoutKind.Start);
    }
}
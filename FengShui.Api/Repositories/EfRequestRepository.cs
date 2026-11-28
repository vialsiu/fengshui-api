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
    
    /// <inheritdoc />
    public async Task UpdateWithInventoryAsync(Request request, List<InventoryItem> inventory)
    {
        //------all or nothing, an inventory should never end up half replaced
        //----ref https://learn.microsoft.com/en-us/ef/core/saving/transactions
        await using var transaction = await Context.Database.BeginTransactionAsync();

        //---old lines go first, the unique index on request + furniture would clash with the new ones
        await Context.InventoryItems
            .Where(i => i.RequestId == request.Id)
            .ExecuteDeleteAsync();

        foreach (var item in inventory)
            item.RequestId = request.Id;
        Context.InventoryItems.AddRange(inventory);

        //--------the request is tracked, so its changed details save without calling Update
        await Context.SaveChangesAsync();
        await transaction.CommitAsync();
    }

    /// <inheritdoc />
    public async Task DeleteWithLayoutsAsync(Request request)
    {
        //-----layouts point at the request but don't cascade, same problem as deleting a client
        await using var transaction = await Context.Database.BeginTransactionAsync();

        await Context.Layouts
            .Where(l => l.RequestId == request.Id)
            .ExecuteDeleteAsync();

        //---inventory items cascade from the request
        Set.Remove(request);
        await Context.SaveChangesAsync();

        await transaction.CommitAsync();
    }
}
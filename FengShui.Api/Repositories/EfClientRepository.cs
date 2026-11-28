//------clients in sqlite, always with their requests so the count is right
using FengShui.Api.Data;
using FengShui.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FengShui.Api.Repositories;

/// <summary>
///---- ef core storage for clients
/// </summary>
/// <param name="context">the database</param>
public class EfClientRepository(FengShuiContext context)
    : EfRepository<Client>(context), IClientRepository
{
    /// <inheritdoc />
    public async Task<List<Client>> GetAllWithRequestsAsync()
    {
        return await Set.Include(c => c.Requests).OrderBy(c => c.Id).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Client?> GetWithRequestsAsync(int id)
    {
        return await Set.Include(c => c.Requests).FirstOrDefaultAsync(c => c.Id == id);
    }

    /// <inheritdoc />
    public async Task DeleteWithRequestsAsync(Client client)
    {
        //---layouts point at requests but don't cascade, so they have to go first or sqlite refuses
        //------a transaction means it's all or nothing, no half deleted client if something fails
        //----ref https://learn.microsoft.com/en-us/ef/core/saving/transactions
        await using var transaction = await Context.Database.BeginTransactionAsync();

        var requestIds = await Context.Requests
            .Where(r => r.ClientId == client.Id)
            .Select(r => r.Id)
            .ToListAsync();

        //--placements go with their layouts because that link does cascade
        //-------ref https://learn.microsoft.com/en-us/ef/core/saving/execute-insert-update-delete
        await Context.Layouts
            .Where(l => l.RequestId != null && requestIds.Contains(l.RequestId.Value))
            .ExecuteDeleteAsync();

        //---requests and their inventory items cascade from the client
        Set.Remove(client);
        await Context.SaveChangesAsync();

        await transaction.CommitAsync();
    }
}
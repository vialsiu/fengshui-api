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
}
//----players in sqlite, the api key has a unique index so this lookup is quick
using FengShui.Api.Data;
using FengShui.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FengShui.Api.Repositories;

/// <summary>
///--- ef core storage for players
/// </summary>
/// <param name="context">the database</param>
public class EfPlayerRepository(FengShuiContext context)
    : EfRepository<Player>(context), IPlayerRepository
{
    /// <inheritdoc />
    public async Task<Player?> GetByApiKeyAsync(string apiKey)
    {
        return await Set.FirstOrDefaultAsync(p => p.ApiKey == apiKey);
    }
}
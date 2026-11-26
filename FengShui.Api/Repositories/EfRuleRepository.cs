//--------the rules in sqlite, a rule with no room kind counts in every room
using FengShui.Api.Data;
using FengShui.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FengShui.Api.Repositories;

/// <summary>
///---- ef core storage for the rules
/// </summary>
/// <param name="context">the database</param>
public class EfRuleRepository(FengShuiContext context)
    : EfRepository<Rule>(context), IRuleRepository
{
    /// <inheritdoc />
    public async Task<List<Rule>> GetForRoomKindAsync(RoomKind kind)
    {
        return await Set
            .Where(r => r.RoomKind == null || r.RoomKind == kind)
            .OrderBy(r => r.Id)
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Rule?> GetByCodeAsync(string code)
    {
        return await Set.FirstOrDefaultAsync(r => r.Code == code);
    }
}
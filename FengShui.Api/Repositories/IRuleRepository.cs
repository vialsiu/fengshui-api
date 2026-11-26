//------the feng shui rules, filtered by the kind of room they count for
using FengShui.Api.Models;

namespace FengShui.Api.Repositories;

/// <summary>
///--- storage for the rules
/// </summary>
public interface IRuleRepository : IRepository<Rule>
{
    /// <summary>
    ///--- the rules that count in a kind of room, the ones for every room are always included
    /// </summary>
    /// <param name="kind">the kind of room</param>
    /// <returns>the matching rules</returns>
    Task<List<Rule>> GetForRoomKindAsync(RoomKind kind);

    /// <summary>
    ///--- one rule by its code, like coffin
    /// </summary>
    /// <param name="code">the code</param>
    /// <returns>the rule, or null if no rule has that code</returns>
    Task<Rule?> GetByCodeAsync(string code);
}
//---furniture types, looked up by code because layouts send codes not ids
using FengShui.Api.Models;

namespace FengShui.Api.Repositories;

/// <summary>
///---- storage for furniture types
/// </summary>
public interface IFurnitureTypeRepository : IRepository<FurnitureType>
{
    /// <summary>
    ///--- one furniture type by its code, like bed
    /// </summary>
    /// <param name="code">the code</param>
    /// <returns>the type, or null if no type has that code</returns>
    Task<FurnitureType?> GetByCodeAsync(string code);

    /// <summary>
    /// -- every furniture type whose code is in the list, used when a whole layout comes in
    /// </summary>
    /// <param name="codes">the codes</param>
    /// <returns>the types it found, keyed by code</returns>
    Task<Dictionary<string, FurnitureType>> GetByCodesAsync(IEnumerable<string> codes);
}
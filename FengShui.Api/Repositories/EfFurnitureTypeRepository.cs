//------furniture types in sqlite, sorted by name so the inventory reads nicely
using FengShui.Api.Data;
using FengShui.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FengShui.Api.Repositories;

/// <summary>
///---- ef core storage for furniture types
/// </summary>
/// <param name="context">the database</param>
public class EfFurnitureTypeRepository(FengShuiContext context)
    : EfRepository<FurnitureType>(context), IFurnitureTypeRepository
{
    /// <inheritdoc />
    public override async Task<List<FurnitureType>> GetAllAsync()
    {
        return await Set.OrderBy(f => f.Name).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<FurnitureType?> GetByCodeAsync(string code)
    {
        return await Set.FirstOrDefaultAsync(f => f.Code == code);
    }

    /// <inheritdoc />
    public async Task<bool> IsInUseAsync(int id)
    {
        //----deleting a type that's placed somewhere would wipe those pieces out of people's layouts
        return await Context.Placements.AnyAsync(p => p.FurnitureTypeId == id)
               || await Context.InventoryItems.AnyAsync(i => i.FurnitureTypeId == id);
    }
    
    /// <inheritdoc />
    public async Task<Dictionary<string, FurnitureType>> GetByCodesAsync(IEnumerable<string> codes)
    {
        //---distinct first, a layout with 2 beds only needs to look up "bed" once
        var wanted = codes.Distinct().ToList();
        return await Set.Where(f => wanted.Contains(f.Code)).ToDictionaryAsync(f => f.Code);
    }
}
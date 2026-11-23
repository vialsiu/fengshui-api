//-------the ef core version of IRepository, the other repositories build on this one
using FengShui.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace FengShui.Api.Repositories;

/// <summary>
/// crud for any model, stored with ef core in the sqlite database
/// </summary>
/// <typeparam name="T">the model, like Room or Rule</typeparam>
/// <param name="context">the database</param>
public class EfRepository<T>(FengShuiContext context) : IRepository<T> where T : class
{
    //---protected so the repositories that inherit from this can write their own queries
    /// <summary>the database</summary>
    protected readonly FengShuiContext Context = context;

    /// <summary>the table for T</summary>
    protected DbSet<T> Set => Context.Set<T>();

    /// <inheritdoc />
    public virtual async Task<List<T>> GetAllAsync()
    {
        return await Set.ToListAsync();
    }

    /// <inheritdoc />
    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await Set.FindAsync(id);
    }

    /// <inheritdoc />
    public async Task<bool> ExistsAsync(int id)
    {
        //-----FindAsync checks what's already loaded before going to the database
        return await Set.FindAsync(id) != null;
    }

    /// <inheritdoc />
    public async Task<T> AddAsync(T entity)
    {
        Set.Add(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(T entity)
    {
        Set.Update(entity);
        await Context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task DeleteAsync(T entity)
    {
        Set.Remove(entity);
        await Context.SaveChangesAsync();
    }
}
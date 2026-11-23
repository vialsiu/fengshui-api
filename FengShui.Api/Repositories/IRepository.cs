//----the basic storage jobs every table needs, so controllers never touch ef core directly
namespace FengShui.Api.Repositories;

/// <summary>
/// the crud every repository has, T is the model it stores
/// </summary>
/// <typeparam name="T">the model, like Room or Rule</typeparam>
//------ref https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design
//---ref https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics
public interface IRepository<T> where T : class
{
    /// <summary>
    /// every row
    /// </summary>
    /// <returns>all of them, can be empty</returns>
    Task<List<T>> GetAllAsync();

    /// <summary>
    /// one row by its id
    /// </summary>
    /// <param name="id">the id</param>
    /// <returns>the row, or null if there isn't one</returns>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// true if a row with this id exists
    /// </summary>
    /// <param name="id">the id</param>
    /// <returns>whether it exists</returns>
    Task<bool> ExistsAsync(int id);

    /// <summary>
    /// saves a new row
    /// </summary>
    /// <param name="entity">the new row, its id gets filled in</param>
    /// <returns>the saved row</returns>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// saves changes to a row that already exists
    /// </summary>
    /// <param name="entity">the changed row</param>
    Task UpdateAsync(T entity);

    /// <summary>
    /// deletes a row
    /// </summary>
    /// <param name="entity">the row to delete</param>
    Task DeleteAsync(T entity);
}
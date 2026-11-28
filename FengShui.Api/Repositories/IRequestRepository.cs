//---requests come back with the client, the room and the furniture inventory
using FengShui.Api.Models;

namespace FengShui.Api.Repositories;

/// <summary>
///---- storage for requests and their furniture inventories
/// </summary>
public interface IRequestRepository : IRepository<Request>
{
    /// <summary>
    ///--- every request with its client, room and inventory loaded
    /// </summary>
    /// <returns>the requests</returns>
    Task<List<Request>> GetAllWithDetailsAsync();

    /// <summary>
    ///--- one request with its client, room and inventory loaded
    /// </summary>
    /// <param name="id">request id</param>
    /// <returns>the request, or null if there isn't one</returns>
    Task<Request?> GetWithDetailsAsync(int id);

    /// <summary>
    ///---- the messy layout the request starts from, with its pieces
    /// </summary>
    /// <param name="requestId">request id</param>
    /// <returns>the start layout, or null if it doesn't have one</returns>
    Task<Layout?> GetStartLayoutAsync(int requestId);
   
    /// <summary>
    ///--- saves a changed request and swaps its inventory for a new one
    /// </summary>
    /// <param name="request">the request, already changed and tracked</param>
    /// <param name="inventory">the new inventory lines</param>
    Task UpdateWithInventoryAsync(Request request, List<InventoryItem> inventory);

    /// <summary>
    ///---- deletes a request with its inventory and every layout made for it
    /// </summary>
    /// <param name="request">the request to delete</param>
    Task DeleteWithLayoutsAsync(Request request);
}
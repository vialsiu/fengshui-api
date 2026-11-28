//-----clients come back with their requests so the cards can show how many rooms they want fixed
using FengShui.Api.Models;

namespace FengShui.Api.Repositories;

/// <summary>
///--- storage for clients
/// </summary>
public interface IClientRepository : IRepository<Client>
{
    /// <summary>
    ///---- every client with their requests loaded
    /// </summary>
    /// <returns>the clients</returns>
    Task<List<Client>> GetAllWithRequestsAsync();

    /// <summary>
    ///---- one client with their requests loaded
    /// </summary>
    /// <param name="id">client id</param>
    /// <returns>the client, or null if there isn't one</returns>
    Task<Client?> GetWithRequestsAsync(int id);

    /// <summary>
    ///-- deletes a client with their requests, inventories and every layout made for those requests
    /// </summary>
    /// <param name="client">the client to delete</param>
    Task DeleteWithRequestsAsync(Client client);
}
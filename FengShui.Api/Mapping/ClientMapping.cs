//------clients between the database and the api
using FengShui.Api.DTOs;
using FengShui.Api.Models;

namespace FengShui.Api.Mapping;

/// <summary>
/// model to dto and dto to model for clients
/// </summary>
public static class ClientMapping
{
    /// <summary>
    /// the client card, load their requests first or the count shows 0
    /// </summary>
    /// <param name="client">the stored client</param>
    /// <returns>the dto</returns>
    public static ClientDTO ToDto(this Client client)
    {
        return new ClientDTO
        {
            Id = client.Id,
            Name = client.Name,
            Age = client.Age,
            //---the card only needs how many rooms they want fixed, not the requests themselves
            RequestCount = client.Requests?.Count ?? 0
        };
    }

    /// <summary>
    /// copies what the admin sent onto a client, only call this after it's been validated
    /// </summary>
    /// <param name="dto">what was sent</param>
    /// <param name="target">the client to fill in, new or existing</param>
    public static void CopyTo(this ClientCreateDTO dto, Client target)
    {
        target.Name = dto.Name!.Trim();
        target.Age = dto.Age;
        target.BirthYear = dto.BirthYear;
        EnumText.TryParse<KuaFormula>(dto.KuaFormula, out var formula);
        target.KuaFormula = formula;
    }
}
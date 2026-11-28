//--------requests and their furniture inventory between the database and the api
using FengShui.Api.DTOs;
using FengShui.Api.Models;

namespace FengShui.Api.Mapping;

/// <summary>
/// model to dto and dto to model for requests
/// </summary>
public static class RequestMapping
{
    /// <summary>
    /// the request card, load the client, room and inventory first
    /// </summary>
    /// <param name="request">the stored request</param>
    /// <returns>the dto</returns>
    public static RequestDTO ToDto(this Request request)
    {
        return new RequestDTO
        {
            Id = request.Id,
            ClientId = request.ClientId,
            ClientName = request.Client?.Name,
            RoomId = request.RoomId,
            RoomName = request.Room?.Name,
            Concern = request.Concern.ToText(),
            Quote = request.Quote,
            Note = request.Note,
            //----sorted by name so the inventory tab reads nicely
            Inventory = (request.Inventory ?? new List<InventoryItem>())
                .OrderBy(i => i.FurnitureType?.Name)
                .Select(i => new InventoryItemDTO { Furniture = i.FurnitureType?.Code, Owned = i.Owned })
                .ToList()
        };
    }

    /// <summary>
    /// copies the request's own details, the inventory is handled separately, only call this after it's been validated
    /// </summary>
    /// <param name="dto">what was sent</param>
    /// <param name="target">the request to fill in, new or existing</param>
    public static void CopyTo(this RequestCreateDTO dto, Request target)
    {
        target.ClientId = dto.ClientId;
        target.RoomId = dto.RoomId;
        EnumText.TryParse<Concern>(dto.Concern, out var concern);
        target.Concern = concern;
        target.Quote = dto.Quote!.Trim();
        //---no note is fine, not every client leaves one
        target.Note = string.IsNullOrWhiteSpace(dto.Note) ? null : dto.Note.Trim();
    }
}
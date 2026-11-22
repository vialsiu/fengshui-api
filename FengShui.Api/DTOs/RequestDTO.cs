//---a client asking for one room in their home to be fixed
namespace FengShui.Api.DTOs;

/// <summary>
/// a request to fix one room, with the client's note and what they own
/// </summary>
public class RequestDTO
{
    /// <summary>request id</summary>
    public int Id { get; set; }
    /// <summary>id of the client asking</summary>
    public int ClientId { get; set; }
    /// <summary>name of the client asking</summary>
    public string? ClientName { get; set; }
    /// <summary>id of the room to fix</summary>
    public int RoomId { get; set; }
    /// <summary>name of the room to fix</summary>
    public string? RoomName { get; set; }
    /// <summary>sleep, family, focus or money</summary>
    public string? Concern { get; set; }
    /// <summary>what they said, like i can't sleep since i moved in</summary>
    public string? Quote { get; set; }
    /// <summary>their note, like i took out my wardrobe and plant first, please put them back</summary>
    public string? Note { get; set; }
    /// <summary>every kind of furniture they own for this room and how many</summary>
    public List<InventoryItemDTO> Inventory { get; set; } = new List<InventoryItemDTO>();
}
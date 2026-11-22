//--------admin only, setting up a request and what the client owns
namespace FengShui.Api.DTOs;

/// <summary>
/// what the admin sends to add or change a request
/// </summary>
public class RequestCreateDTO
{
    /// <summary>id of the client asking</summary>
    public int ClientId { get; set; }
    /// <summary>id of the room to fix</summary>
    public int RoomId { get; set; }
    /// <summary>sleep, family, focus or money</summary>
    public string? Concern { get; set; }
    /// <summary>what they said</summary>
    public string? Quote { get; set; }
    /// <summary>their note about what they moved out first</summary>
    public string? Note { get; set; }
    /// <summary>every kind of furniture they own for this room and how many</summary>
    public List<InventoryItemDTO> Inventory { get; set; } = new List<InventoryItemDTO>();
}
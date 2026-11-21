//-----what gets sent to check a layout or find the qi flow, nothing gets saved
namespace FengShui.Api.DTOs;

/// <summary>
/// a layout to check without saving it
/// </summary>
public class LayoutCheckDTO
{
    /// <summary>id of the room</summary>
    public int RoomId { get; set; }
    /// <summary>id of the client, their concern changes which rules count double</summary>
    public int? ClientId { get; set; }
    /// <summary>every piece in the room</summary>
    public List<PlacementDTO> Placements { get; set; } = new List<PlacementDTO>();
}
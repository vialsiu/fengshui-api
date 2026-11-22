//--what the player sends to save a new layout
namespace FengShui.Api.DTOs;

/// <summary>
/// a new layout to save, for a request or for your own room
/// </summary>
public class LayoutCreateDTO
{
    /// <summary>name for the layout</summary>
    public string? Name { get; set; }
    /// <summary>id of the room it's for</summary>
    public int RoomId { get; set; }
    /// <summary>id of the request it's for, leave empty for your own room</summary>
    public int? RequestId { get; set; }
    /// <summary>every piece and where it sits</summary>
    public List<PlacementDTO> Placements { get; set; } = new List<PlacementDTO>();
}
//-----a saved layout, every piece of furniture and where it sits
namespace FengShui.Api.DTOs;

/// <summary>
/// a layout for a room, either the messy start, an example or one a player saved
/// </summary>
public class LayoutDTO
{
    /// <summary>layout id</summary>
    public int Id { get; set; }
    /// <summary>start, example or player</summary>
    public string? Kind { get; set; }
    /// <summary>name the player gave it</summary>
    public string? Name { get; set; }
    /// <summary>id of the room it's for</summary>
    public int RoomId { get; set; }
    /// <summary>id of the request it's for, empty when it's your own room</summary>
    public int? RequestId { get; set; }
    /// <summary>every piece and where it sits</summary>
    public List<PlacementDTO> Placements { get; set; } = new List<PlacementDTO>();
    /// <summary>when it was last saved</summary>
    public DateTime UpdatedAt { get; set; }
}
//------a saved arrangement of a room
namespace FengShui.Api.DTOs;

/// <summary>
/// a layout as the api returns it
/// </summary>
public class LayoutDTO
{
    /// <summary>layout id</summary>
    public int Id { get; set; }
    /// <summary>start (the messy one), example (a gold one) or player</summary>
    public string? Kind { get; set; }
    /// <summary>layout name</summary>
    public string? Name { get; set; }
    /// <summary>id of the room it's for</summary>
    public int RoomId { get; set; }
    /// <summary>id of the client it's for, empty for your own room</summary>
    public int? ClientId { get; set; }
    /// <summary>every piece in the room</summary>
    public List<PlacementDTO> Placements { get; set; } = new List<PlacementDTO>();
    /// <summary>when it was last saved</summary>
    public DateTime UpdatedAt { get; set; }
}
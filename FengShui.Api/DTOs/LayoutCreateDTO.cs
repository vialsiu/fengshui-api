//----saving a new layout, the player comes from the api key so it's not in here
namespace FengShui.Api.DTOs;

/// <summary>
/// what a player sends to save a new layout
/// </summary>
public class LayoutCreateDTO
{
    /// <summary>layout name</summary>
    public string? Name { get; set; }
    /// <summary>id of the room it's for</summary>
    public int RoomId { get; set; }
    /// <summary>id of the client it's for, leave empty for your own room</summary>
    public int? ClientId { get; set; }
    /// <summary>every piece in the room</summary>
    public List<PlacementDTO> Placements { get; set; } = new List<PlacementDTO>();
}
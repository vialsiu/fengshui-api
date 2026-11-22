//-------changing a saved layout, the room and client stay the same
namespace FengShui.Api.DTOs;

/// <summary>
/// what a player sends to change a layout they saved
/// </summary>
public class LayoutUpdateDTO
{
    /// <summary>layout name</summary>
    public string? Name { get; set; }
    /// <summary>every piece in the room</summary>
    public List<PlacementDTO> Placements { get; set; } = new List<PlacementDTO>();
}
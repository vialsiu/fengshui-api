//------a layout sent in just to be checked, nothing gets saved
namespace FengShui.Api.DTOs;

/// <summary>
/// a layout to check against the rules or to find the qi flow for
/// </summary>
public class LayoutCheckDTO
{
    /// <summary>id of the room</summary>
    public int RoomId { get; set; }
    /// <summary>id of the request, so the client's kua and furniture count too</summary>
    public int? RequestId { get; set; }
    /// <summary>every piece and where it sits</summary>
    public List<PlacementDTO> Placements { get; set; } = new List<PlacementDTO>();
}
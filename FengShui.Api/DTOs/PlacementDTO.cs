//---one piece of furniture sitting in a room
namespace FengShui.Api.DTOs;

/// <summary>
/// one piece of furniture in a layout, no database ids, just the furniture code
/// </summary>
public class PlacementDTO
{
    /// <summary>furniture code, like bed or sofa</summary>
    public string? Furniture { get; set; }
    /// <summary>half-square column of the top left corner, starts at 1</summary>
    public int Col { get; set; }
    /// <summary>half-square row of the top left corner, starts at 1</summary>
    public int Row { get; set; }
    /// <summary>0, 90, 180 or 270</summary>
    public int Rotation { get; set; }
}
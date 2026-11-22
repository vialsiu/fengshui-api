//----which wall of the room something is on, looking down from above
namespace FengShui.Api.Models;

/// <summary>
/// the four walls of a room, top is the far wall on the grid
/// </summary>
public enum Wall
{
    /// <summary>the far wall</summary>
    Top,
    /// <summary>the right wall</summary>
    Right,
    /// <summary>the near wall</summary>
    Bottom,
    /// <summary>the left wall</summary>
    Left
}

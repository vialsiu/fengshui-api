//-----just one half-square, used for the qi path
namespace FengShui.Api.DTOs;

/// <summary>
/// one half-square in the room
/// </summary>
public class SquareDTO
{
    /// <summary>column, starts at 1</summary>
    public int Col { get; set; }
    /// <summary>row, starts at 1</summary>
    public int Row { get; set; }
}
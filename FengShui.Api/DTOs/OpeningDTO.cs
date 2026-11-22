//----a door or a window, used inside the room dtos
namespace FengShui.Api.DTOs;

/// <summary>
/// a door or window, which wall it's on and where it sits along it
/// </summary>
public class OpeningDTO
{
    /// <summary>top, right, bottom or left</summary>
    public string? Wall { get; set; }
    /// <summary>half-square where it starts</summary>
    public int From { get; set; }
    /// <summary>half-square where it stops (not included)</summary>
    public int To { get; set; }
}
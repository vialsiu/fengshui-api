//---editing your own room, the kind of room stays the same so it's not in here
namespace FengShui.Api.DTOs;

/// <summary>
/// what a player sends to change their own room
/// </summary>
public class RoomUpdateDTO
{
    /// <summary>room name</summary>
    public string? Name { get; set; }
    /// <summary>width in half-squares</summary>
    public int Cols { get; set; }
    /// <summary>length in half-squares</summary>
    public int Rows { get; set; }
    /// <summary>where the door is</summary>
    public OpeningDTO? Door { get; set; }
    /// <summary>where the window is</summary>
    public OpeningDTO? Window { get; set; }
    /// <summary>which wall faces north, top, right, bottom or left</summary>
    public string? NorthWall { get; set; }
}
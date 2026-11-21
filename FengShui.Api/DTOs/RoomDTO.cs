//-----a room the way the api hands it back, sizes are in half-squares (25cm)
namespace FengShui.Api.DTOs;

/// <summary>
/// a room as the api returns it, sizes are in half-squares
/// </summary>
public class RoomDTO
{
    /// <summary>room id</summary>
    public int Id { get; set; }
    /// <summary>room name, like the bedroom</summary>
    public string? Name { get; set; }
    /// <summary>bedroom, living or study</summary>
    public string? Kind { get; set; }
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
    /// <summary>true if the player asking made this room</summary>
    public bool IsMine { get; set; }
}
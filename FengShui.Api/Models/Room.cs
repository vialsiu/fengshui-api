//-----a room, either one of the game's or one a player made
namespace FengShui.Api.Models;

/// <summary>
/// a room, sizes are in half-squares, the door and window are stored as flat columns
/// </summary>
public class Room
{
    /// <summary>room id</summary>
    public int Id { get; set; }
    /// <summary>room name, like the twins' bedroom</summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>bedroom, living or study</summary>
    public RoomKind Kind { get; set; }
    /// <summary>width in half-squares</summary>
    public int Cols { get; set; }
    /// <summary>length in half-squares</summary>
    public int Rows { get; set; }

    //----the dto has a door object, here it's three plain columns
    /// <summary>wall the door is on</summary>
    public Wall DoorWall { get; set; }
    /// <summary>half-square where the door starts</summary>
    public int DoorFrom { get; set; }
    /// <summary>half-square where the door stops (not included)</summary>
    public int DoorTo { get; set; }

    /// <summary>wall the window is on</summary>
    public Wall WindowWall { get; set; }
    /// <summary>half-square where the window starts</summary>
    public int WindowFrom { get; set; }
    /// <summary>half-square where the window stops (not included)</summary>
    public int WindowTo { get; set; }

    /// <summary>which wall faces north</summary>
    public Wall NorthWall { get; set; }

    //-------empty for the game's own rooms, filled in when a player makes one
    /// <summary>id of the player who made it, empty for the game's rooms</summary>
    public int? PlayerId { get; set; }
    /// <summary>the player who made it</summary>
    public Player? Player { get; set; }

    /// <summary>requests asking for this room to be fixed</summary>
    public ICollection<Request>? Requests { get; set; } = new List<Request>();
    /// <summary>layouts made for this room</summary>
    public ICollection<Layout>? Layouts { get; set; } = new List<Layout>();
}

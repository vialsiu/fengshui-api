//---a layout, every piece of furniture in a room and where it sits
namespace FengShui.Api.Models;

/// <summary>
/// a layout for a room, the messy start, an example or one a player saved
/// </summary>
public class Layout
{
    /// <summary>layout id</summary>
    public int Id { get; set; }
    /// <summary>start, example or player</summary>
    public LayoutKind Kind { get; set; }
    /// <summary>name for it, like attempt 2</summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>id of the room it's for</summary>
    public int RoomId { get; set; }
    /// <summary>the room it's for</summary>
    public Room Room { get; set; } = null!;

    //------empty when a player is fixing their own room
    /// <summary>id of the request it's for</summary>
    public int? RequestId { get; set; }
    /// <summary>the request it's for</summary>
    public Request? Request { get; set; }

    //--------empty for start and example layouts, they belong to the game
    /// <summary>id of the player who saved it</summary>
    public int? PlayerId { get; set; }
    /// <summary>the player who saved it</summary>
    public Player? Player { get; set; }

    /// <summary>when it was last saved</summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>every piece and where it sits</summary>
    public ICollection<Placement>? Placements { get; set; } = new List<Placement>();
}

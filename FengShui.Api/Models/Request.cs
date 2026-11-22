//--------a client asking for one room in their home to be fixed
namespace FengShui.Api.Models;

/// <summary>
/// a request to fix one room, with the client's note and the furniture they own
/// </summary>
public class Request
{
    /// <summary>request id</summary>
    public int Id { get; set; }

    /// <summary>id of the client asking</summary>
    public int ClientId { get; set; }
    /// <summary>the client asking</summary>
    public Client Client { get; set; } = null!;

    /// <summary>id of the room to fix</summary>
    public int RoomId { get; set; }
    /// <summary>the room to fix</summary>
    public Room Room { get; set; } = null!;

    /// <summary>sleep, family, focus or money</summary>
    public Concern Concern { get; set; }
    /// <summary>what they said, like i can't sleep since i moved in</summary>
    public string Quote { get; set; } = string.Empty;
    /// <summary>their note, like i took out my wardrobe first, please put it back</summary>
    public string? Note { get; set; }

    //----what they own for this room, the layout can't use more than this
    /// <summary>every kind of furniture they own for this room</summary>
    public ICollection<InventoryItem>? Inventory { get; set; } = new List<InventoryItem>();
    /// <summary>layouts made for this request, including the start one</summary>
    public ICollection<Layout>? Layouts { get; set; } = new List<Layout>();
}

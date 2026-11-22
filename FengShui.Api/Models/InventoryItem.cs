//-----how many of one kind of furniture a client owns, like 2 beds for the twins
namespace FengShui.Api.Models;

/// <summary>
/// one line of a request's furniture inventory
/// </summary>
public class InventoryItem
{
    /// <summary>inventory item id</summary>
    public int Id { get; set; }

    /// <summary>id of the request it belongs to</summary>
    public int RequestId { get; set; }
    /// <summary>the request it belongs to</summary>
    public Request Request { get; set; } = null!;

    /// <summary>id of the kind of furniture</summary>
    public int FurnitureTypeId { get; set; }
    /// <summary>the kind of furniture</summary>
    public FurnitureType FurnitureType { get; set; } = null!;

    /// <summary>how many they own</summary>
    public int Owned { get; set; }
}

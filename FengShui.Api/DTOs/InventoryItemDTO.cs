//-----one thing a client owns for a request, like 2 beds for the twins
namespace FengShui.Api.DTOs;

/// <summary>
/// one kind of furniture the client owns and how many
/// </summary>
public class InventoryItemDTO
{
    /// <summary>furniture code, like bed</summary>
    public string? Furniture { get; set; }
    /// <summary>how many they own, the inventory shows this minus however many are placed</summary>
    public int Owned { get; set; }
}
//-----one kind of furniture, like a double bed or a rug
namespace FengShui.Api.Models;

/// <summary>
/// a kind of furniture, its size in squares and its element
/// </summary>
public class FurnitureType
{
    /// <summary>furniture type id</summary>
    public int Id { get; set; }
    /// <summary>short code used in layouts, like bed_double</summary>
    public string Code { get; set; } = string.Empty;
    /// <summary>name shown to the player</summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>how many squares wide before it's rotated</summary>
    public int Width { get; set; }
    /// <summary>how many squares deep before it's rotated</summary>
    public int Height { get; set; }
    /// <summary>true for things like rugs that qi can flow over</summary>
    public bool IsFlat { get; set; }
    /// <summary>its element, empty if it doesn't have one</summary>
    public Element? Element { get; set; }
}

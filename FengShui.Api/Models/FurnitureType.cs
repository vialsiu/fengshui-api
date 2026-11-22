//-----one kind of furniture, like a bed or a rug
namespace FengShui.Api.Models;

/// <summary>
/// a kind of furniture, its size in half-squares and its element
/// </summary>
public class FurnitureType
{
    /// <summary>furniture type id</summary>
    public int Id { get; set; }
    /// <summary>short code used in layouts, like bed</summary>
    public string Code { get; set; } = string.Empty;
    /// <summary>the name players see</summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>width in half-squares before it's rotated</summary>
    public int Width { get; set; }
    /// <summary>depth in half-squares before it's rotated</summary>
    public int Height { get; set; }
    /// <summary>true for stuff qi can flow over, like a rug</summary>
    public bool IsFlat { get; set; }
    /// <summary>its element, empty if it doesn't have one</summary>
    public Element? Element { get; set; }
}
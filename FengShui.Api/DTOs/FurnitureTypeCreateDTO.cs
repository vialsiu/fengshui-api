//----admin only, adding or changing a kind of furniture
namespace FengShui.Api.DTOs;

/// <summary>
/// what the admin sends to add or change a kind of furniture
/// </summary>
public class FurnitureTypeCreateDTO
{
    /// <summary>short code used in layouts, like bed</summary>
    public string? Code { get; set; }
    /// <summary>the name players see</summary>
    public string? Name { get; set; }
    /// <summary>width in half-squares</summary>
    public int Width { get; set; }
    /// <summary>depth in half-squares</summary>
    public int Height { get; set; }
    /// <summary>true for stuff you can walk over, like a rug</summary>
    public bool IsFlat { get; set; }
    /// <summary>wood, fire, earth, metal or water</summary>
    public string? Element { get; set; }
}
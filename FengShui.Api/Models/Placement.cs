//----one piece of furniture sitting somewhere in a layout
namespace FengShui.Api.Models;

/// <summary>
/// one piece in a layout, stored by furniture id, the dto uses the code instead
/// </summary>
public class Placement
{
    /// <summary>placement id</summary>
    public int Id { get; set; }

    /// <summary>id of the layout it's in</summary>
    public int LayoutId { get; set; }
    /// <summary>the layout it's in</summary>
    public Layout Layout { get; set; } = null!;

    /// <summary>id of the kind of furniture</summary>
    public int FurnitureTypeId { get; set; }
    /// <summary>the kind of furniture</summary>
    public FurnitureType FurnitureType { get; set; } = null!;

    /// <summary>half-square column of the top left corner, starts at 1</summary>
    public int Col { get; set; }
    /// <summary>half-square row of the top left corner, starts at 1</summary>
    public int Row { get; set; }
    /// <summary>0, 90, 180 or 270</summary>
    public int Rotation { get; set; }
}

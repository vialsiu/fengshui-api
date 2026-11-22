//----every kind of furniture in the game, sizes are in half-squares (25cm)
using FengShui.Api.Models;

namespace FengShui.Api.Data.Seed;

/// <summary>
/// the furniture types the game starts with
/// </summary>
public static class FurnitureTypeSeed
{
    //-------ids are written out by hand because HasData needs them
    //---ref https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding#model-managed-data
    /// <summary>
    /// all the starting furniture types
    /// </summary>
    public static readonly FurnitureType[] All =
    [
        new FurnitureType { Id = 1, Code = "bed", Name = "Double bed", Width = 6, Height = 8, IsFlat = false, Element = Element.Earth },
        new FurnitureType { Id = 2, Code = "single_bed", Name = "Single bed", Width = 4, Height = 8, IsFlat = false, Element = Element.Earth },
        new FurnitureType { Id = 3, Code = "nightstand", Name = "Nightstand", Width = 2, Height = 2, IsFlat = false, Element = Element.Wood },
        new FurnitureType { Id = 4, Code = "wardrobe", Name = "Wardrobe", Width = 4, Height = 2, IsFlat = false, Element = Element.Wood },
        new FurnitureType { Id = 5, Code = "dresser", Name = "Dresser", Width = 4, Height = 2, IsFlat = false, Element = Element.Wood },
        new FurnitureType { Id = 6, Code = "desk", Name = "Desk", Width = 5, Height = 3, IsFlat = false, Element = Element.Wood },
        new FurnitureType { Id = 7, Code = "chair", Name = "Desk chair", Width = 2, Height = 2, IsFlat = false, Element = Element.Metal },
        new FurnitureType { Id = 8, Code = "bookshelf", Name = "Bookshelf", Width = 4, Height = 1, IsFlat = false, Element = Element.Wood },
        new FurnitureType { Id = 9, Code = "sofa", Name = "Sofa", Width = 8, Height = 4, IsFlat = false, Element = Element.Earth },
        new FurnitureType { Id = 10, Code = "armchair", Name = "Armchair", Width = 3, Height = 3, IsFlat = false, Element = Element.Earth },
        new FurnitureType { Id = 11, Code = "coffee_table", Name = "Coffee table", Width = 4, Height = 2, IsFlat = false, Element = Element.Wood },
        new FurnitureType { Id = 12, Code = "tv_unit", Name = "TV unit", Width = 6, Height = 2, IsFlat = false, Element = Element.Fire },
        //---flat, so qi flows straight over it
        new FurnitureType { Id = 13, Code = "rug", Name = "Rug", Width = 8, Height = 6, IsFlat = true, Element = Element.Earth },
        new FurnitureType { Id = 14, Code = "plant", Name = "Plant", Width = 2, Height = 2, IsFlat = false, Element = Element.Wood },
        new FurnitureType { Id = 15, Code = "lamp", Name = "Floor lamp", Width = 1, Height = 1, IsFlat = false, Element = Element.Fire },
        new FurnitureType { Id = 16, Code = "mirror", Name = "Mirror", Width = 3, Height = 1, IsFlat = false, Element = Element.Water }
    ];
}
//------what each client owns for each request, the layout can't use more than this
using FengShui.Api.Models;

namespace FengShui.Api.Data.Seed;

/// <summary>
/// the furniture inventory for every starting request
/// </summary>
public static class InventoryItemSeed
{
    //----furniture type ids: 1 bed, 2 single bed, 3 nightstand, 4 wardrobe, 5 dresser, 6 desk, 7 chair, 8 bookshelf,
    //----9 sofa, 10 armchair, 11 coffee table, 12 tv unit, 13 rug, 14 plant, 15 lamp, 16 mirror
    /// <summary>
    /// every inventory line for the starting requests
    /// </summary>
    public static readonly InventoryItem[] All =
    [
        //---maya's bedroom
        new InventoryItem { Id = 1, RequestId = 1, FurnitureTypeId = 1, Owned = 1 },
        new InventoryItem { Id = 2, RequestId = 1, FurnitureTypeId = 3, Owned = 2 },
        new InventoryItem { Id = 3, RequestId = 1, FurnitureTypeId = 4, Owned = 1 },
        new InventoryItem { Id = 4, RequestId = 1, FurnitureTypeId = 5, Owned = 1 },
        new InventoryItem { Id = 5, RequestId = 1, FurnitureTypeId = 14, Owned = 1 },
        new InventoryItem { Id = 6, RequestId = 1, FurnitureTypeId = 16, Owned = 1 },

        //-------the twins, two of the same bed
        new InventoryItem { Id = 7, RequestId = 2, FurnitureTypeId = 2, Owned = 2 },
        new InventoryItem { Id = 8, RequestId = 2, FurnitureTypeId = 3, Owned = 1 },
        new InventoryItem { Id = 9, RequestId = 2, FurnitureTypeId = 8, Owned = 1 },
        new InventoryItem { Id = 10, RequestId = 2, FurnitureTypeId = 13, Owned = 1 },
        new InventoryItem { Id = 11, RequestId = 2, FurnitureTypeId = 15, Owned = 1 },

        //--the okafor living room
        new InventoryItem { Id = 12, RequestId = 3, FurnitureTypeId = 9, Owned = 1 },
        new InventoryItem { Id = 13, RequestId = 3, FurnitureTypeId = 10, Owned = 2 },
        new InventoryItem { Id = 14, RequestId = 3, FurnitureTypeId = 11, Owned = 1 },
        new InventoryItem { Id = 15, RequestId = 3, FurnitureTypeId = 12, Owned = 1 },
        new InventoryItem { Id = 16, RequestId = 3, FurnitureTypeId = 13, Owned = 1 },
        new InventoryItem { Id = 17, RequestId = 3, FurnitureTypeId = 14, Owned = 2 },

        //-----tom's study
        new InventoryItem { Id = 18, RequestId = 4, FurnitureTypeId = 6, Owned = 1 },
        new InventoryItem { Id = 19, RequestId = 4, FurnitureTypeId = 7, Owned = 1 },
        new InventoryItem { Id = 20, RequestId = 4, FurnitureTypeId = 8, Owned = 2 },
        new InventoryItem { Id = 21, RequestId = 4, FurnitureTypeId = 15, Owned = 1 },

        //----declan's home office
        new InventoryItem { Id = 22, RequestId = 5, FurnitureTypeId = 6, Owned = 1 },
        new InventoryItem { Id = 23, RequestId = 5, FurnitureTypeId = 7, Owned = 1 },
        new InventoryItem { Id = 24, RequestId = 5, FurnitureTypeId = 10, Owned = 1 },
        new InventoryItem { Id = 25, RequestId = 5, FurnitureTypeId = 8, Owned = 1 },
        new InventoryItem { Id = 26, RequestId = 5, FurnitureTypeId = 14, Owned = 1 }
    ];
}

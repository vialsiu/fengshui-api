//------where every piece sits in the starting layouts, each one breaks a few rules on purpose
using FengShui.Api.Models;

namespace FengShui.Api.Data.Seed;

/// <summary>
/// the pieces in every start layout, only what the client didn't take out
/// </summary>
public static class PlacementSeed
{
    //---col and row are the top left corner in half-squares, counted from 1
    //---furniture type ids: 1 bed, 2 single bed, 3 nightstand, 6 desk, 7 chair, 8 bookshelf, 9 sofa,
    //---10 armchair, 11 coffee table, 12 tv unit, 13 rug, 14 plant, 15 lamp, 16 mirror
    /// <summary>
    /// every placement in the starting layouts
    /// </summary>
    public static readonly Placement[] All =
    [
        //-----maya: bed under the window with her feet pointing at the door (coffin), mirror facing the bed
        //-----the wardrobe, dresser and plant are out, she took them out herself
        new Placement { Id = 1, LayoutId = 1, FurnitureTypeId = 1, Col = 4, Row = 1, Rotation = 0 },
        new Placement { Id = 2, LayoutId = 1, FurnitureTypeId = 3, Col = 2, Row = 1, Rotation = 0 },
        new Placement { Id = 3, LayoutId = 1, FurnitureTypeId = 3, Col = 10, Row = 1, Rotation = 0 },
        new Placement { Id = 4, LayoutId = 1, FurnitureTypeId = 16, Col = 6, Row = 16, Rotation = 0 },

        //--------twins: both beds are out in the hall, and the bookshelf is turned sideways in front of the door
        new Placement { Id = 5, LayoutId = 2, FurnitureTypeId = 3, Col = 15, Row = 1, Rotation = 0 },
        new Placement { Id = 6, LayoutId = 2, FurnitureTypeId = 8, Col = 1, Row = 11, Rotation = 90 },
        new Placement { Id = 7, LayoutId = 2, FurnitureTypeId = 13, Col = 5, Row = 6, Rotation = 0 },
        new Placement { Id = 8, LayoutId = 2, FurnitureTypeId = 15, Col = 16, Row = 16, Rotation = 0 },

        //--living room: sofa floating in the middle with its back to the door, an armchair right in front of the door
        new Placement { Id = 9, LayoutId = 3, FurnitureTypeId = 9, Col = 7, Row = 9, Rotation = 0 },
        new Placement { Id = 10, LayoutId = 3, FurnitureTypeId = 10, Col = 15, Row = 15, Rotation = 0 },
        new Placement { Id = 11, LayoutId = 3, FurnitureTypeId = 10, Col = 1, Row = 1, Rotation = 0 },
        new Placement { Id = 12, LayoutId = 3, FurnitureTypeId = 11, Col = 9, Row = 6, Rotation = 0 },
        new Placement { Id = 13, LayoutId = 3, FurnitureTypeId = 12, Col = 9, Row = 17, Rotation = 0 },
        new Placement { Id = 14, LayoutId = 3, FurnitureTypeId = 13, Col = 1, Row = 12, Rotation = 0 },
        new Placement { Id = 15, LayoutId = 3, FurnitureTypeId = 14, Col = 19, Row = 1, Rotation = 0 },
        new Placement { Id = 16, LayoutId = 3, FurnitureTypeId = 14, Col = 1, Row = 5, Rotation = 0 },

        //----tom: the desk is in pieces so it's not placed yet, just the chair and shelves
        new Placement { Id = 17, LayoutId = 4, FurnitureTypeId = 7, Col = 6, Row = 6, Rotation = 0 },
        new Placement { Id = 18, LayoutId = 4, FurnitureTypeId = 8, Col = 1, Row = 1, Rotation = 0 },
        new Placement { Id = 19, LayoutId = 4, FurnitureTypeId = 8, Col = 5, Row = 12, Rotation = 0 },
        new Placement { Id = 20, LayoutId = 4, FurnitureTypeId = 15, Col = 12, Row = 12, Rotation = 0 },

        //-------declan: sitting with his back to the door, a bookshelf blocking the window
        new Placement { Id = 21, LayoutId = 5, FurnitureTypeId = 6, Col = 9, Row = 4, Rotation = 0 },
        new Placement { Id = 22, LayoutId = 5, FurnitureTypeId = 7, Col = 10, Row = 2, Rotation = 0 },
        new Placement { Id = 23, LayoutId = 5, FurnitureTypeId = 10, Col = 1, Row = 1, Rotation = 0 },
        new Placement { Id = 24, LayoutId = 5, FurnitureTypeId = 8, Col = 3, Row = 12, Rotation = 0 },
        new Placement { Id = 25, LayoutId = 5, FurnitureTypeId = 14, Col = 13, Row = 11, Rotation = 0 }
    ];
}
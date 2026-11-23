//---the game's own rooms, sizes are in half-squares (25cm), so 16 is 4 metres
using FengShui.Api.Models;

namespace FengShui.Api.Data.Seed;

/// <summary>
/// the rooms the clients want fixed, none of them belong to a player
/// </summary>
public static class RoomSeed
{
    //------door and window go from one half-square up to (not including) another, counted from 1
    /// <summary>
    /// all the starting rooms
    /// </summary>
    public static readonly Room[] All =
    [
        new Room { Id = 1, Name = "Maya's bedroom", Kind = RoomKind.Bedroom, Cols = 14, Rows = 16,
            DoorWall = Wall.Bottom, DoorFrom = 2, DoorTo = 6,
            WindowWall = Wall.Top, WindowFrom = 5, WindowTo = 11,
            NorthWall = Wall.Top },
        new Room { Id = 2, Name = "The twins' bedroom", Kind = RoomKind.Bedroom, Cols = 16, Rows = 16,
            DoorWall = Wall.Left, DoorFrom = 11, DoorTo = 15,
            WindowWall = Wall.Right, WindowFrom = 4, WindowTo = 10,
            NorthWall = Wall.Right },
        new Room { Id = 3, Name = "The Okafor living room", Kind = RoomKind.Living, Cols = 20, Rows = 18,
            DoorWall = Wall.Bottom, DoorFrom = 15, DoorTo = 19,
            WindowWall = Wall.Top, WindowFrom = 4, WindowTo = 12,
            NorthWall = Wall.Left },
        new Room { Id = 4, Name = "Tom's study", Kind = RoomKind.Study, Cols = 12, Rows = 12,
            DoorWall = Wall.Right, DoorFrom = 2, DoorTo = 6,
            WindowWall = Wall.Left, WindowFrom = 4, WindowTo = 9,
            NorthWall = Wall.Bottom },
        new Room { Id = 5, Name = "Declan's home office", Kind = RoomKind.Study, Cols = 14, Rows = 12,
            DoorWall = Wall.Top, DoorFrom = 10, DoorTo = 14,
            WindowWall = Wall.Bottom, WindowFrom = 3, WindowTo = 9,
            NorthWall = Wall.Bottom }
    ];
}

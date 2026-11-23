//----the messy starting layout for each request, what the room looks like when you first open it
using FengShui.Api.Models;

namespace FengShui.Api.Data.Seed;

/// <summary>
/// one start layout per request, they belong to the game so there's no player
/// </summary>
public static class LayoutSeed
{
    //-------HasData needs fixed values, DateTime.Now would change every build and make a new migration each time
    private static readonly DateTime Seeded = new DateTime(2026, 11, 23, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// all the starting layouts
    /// </summary>
    public static readonly Layout[] All =
    [
        new Layout { Id = 1, Kind = LayoutKind.Start, Name = "Maya's bedroom as it is", RoomId = 1, RequestId = 1, UpdatedAt = Seeded },
        new Layout { Id = 2, Kind = LayoutKind.Start, Name = "The twins' bedroom as it is", RoomId = 2, RequestId = 2, UpdatedAt = Seeded },
        new Layout { Id = 3, Kind = LayoutKind.Start, Name = "The Okafor living room as it is", RoomId = 3, RequestId = 3, UpdatedAt = Seeded },
        new Layout { Id = 4, Kind = LayoutKind.Start, Name = "Tom's study as it is", RoomId = 4, RequestId = 4, UpdatedAt = Seeded },
        new Layout { Id = 5, Kind = LayoutKind.Start, Name = "Declan's home office as it is", RoomId = 5, RequestId = 5, UpdatedAt = Seeded }
    ];
}
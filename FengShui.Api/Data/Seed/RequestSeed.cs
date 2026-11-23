//--------what each client wants fixed, what they said and the note they left
using FengShui.Api.Models;

namespace FengShui.Api.Data.Seed;

/// <summary>
/// the requests the game starts with, one room each
/// </summary>
public static class RequestSeed
{
    /// <summary>
    /// all the starting requests
    /// </summary>
    public static readonly Request[] All =
    [
        new Request { Id = 1, ClientId = 1, RoomId = 1, Concern = Concern.Sleep,
            Quote = "I haven't slept properly since I moved in.",
            Note = "I removed my wardrobe, plant and dresser from my room first to make it easier for you. Please don't forget to put them back!" },
        new Request { Id = 2, ClientId = 2, RoomId = 2, Concern = Concern.Family,
            Quote = "The boys fight every single night at bedtime.",
            Note = "Both beds are out in the hall, they're too heavy for me to put back on my own." },
        new Request { Id = 3, ClientId = 2, RoomId = 3, Concern = Concern.Family,
            Quote = "We never sit together in the living room anymore." },
        new Request { Id = 4, ClientId = 3, RoomId = 4, Concern = Concern.Focus,
            Quote = "I can't get anything done on my thesis in here.",
            Note = "I took the desk apart to get it up the stairs, sorry! It's in pieces by the door." },
        new Request { Id = 5, ClientId = 4, RoomId = 5, Concern = Concern.Money,
            Quote = "Money comes in and goes straight back out again." }
    ];
}

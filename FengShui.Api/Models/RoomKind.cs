//-------what kind of room it is, some rules only count for one kind
namespace FengShui.Api.Models;

/// <summary>
/// the kinds of room in the game
/// </summary>
public enum RoomKind
{
    /// <summary>a bedroom</summary>
    Bedroom,
    /// <summary>a living room</summary>
    Living,
    /// <summary>a study or home office</summary>
    Study
}
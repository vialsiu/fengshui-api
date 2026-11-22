//--------where a layout came from
namespace FengShui.Api.Models;

/// <summary>
/// the three kinds of layout
/// </summary>
public enum LayoutKind
{
    /// <summary>the messy room the client starts with</summary>
    Start,
    /// <summary>a good layout the game ships with</summary>
    Example,
    /// <summary>one a player saved</summary>
    Player
}

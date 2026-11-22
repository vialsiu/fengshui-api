//------groups the rules so the results can be shown by type
namespace FengShui.Api.Models;

/// <summary>
/// what part of feng shui a rule is about
/// </summary>
public enum RuleCategory
{
    /// <summary>command position, like seeing the door from the bed</summary>
    Command,
    /// <summary>qi flow, like nothing blocking the path from the door</summary>
    Flow,
    /// <summary>the five elements and how they balance</summary>
    Elements,
    /// <summary>the bagua life areas</summary>
    Bagua,
    /// <summary>the client's own kua directions</summary>
    Kua
}

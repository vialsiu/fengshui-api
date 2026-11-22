//------groups the rules so the cards can be shown by type
namespace FengShui.Api.Models;

/// <summary>
/// who or what a rule is about
/// </summary>
public enum RuleCategory
{
    /// <summary>only counts for one kind of room, like the bed seeing the door</summary>
    Room,
    /// <summary>counts in every room, like nothing blocking the door</summary>
    General,
    /// <summary>depends on the client, like their kua directions</summary>
    Personal
}
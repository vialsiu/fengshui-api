//--------one feng shui rule the layout checker tests
namespace FengShui.Api.Models;

/// <summary>
/// a feng shui rule, why it matters and how much breaking it costs
/// </summary>
public class Rule
{
    /// <summary>rule id</summary>
    public int Id { get; set; }
    /// <summary>short code the checker uses, like bed_sees_door</summary>
    public string Code { get; set; } = string.Empty;
    /// <summary>short title, like the bed can see the door</summary>
    public string Title { get; set; } = string.Empty;
    /// <summary>the reason behind it, shown when it's broken</summary>
    public string? Why { get; set; }
    /// <summary>what part of feng shui it's about</summary>
    public RuleCategory Category { get; set; }
    /// <summary>1 to 3, how much harmony is lost when it's broken</summary>
    public int Severity { get; set; }
    /// <summary>the only kind of room it counts for, empty means every room</summary>
    public RoomKind? RoomKind { get; set; }
}

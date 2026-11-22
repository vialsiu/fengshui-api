//--------one feng shui rule the layout checker tests
namespace FengShui.Api.Models;

/// <summary>
/// a feng shui rule, why it matters and how much breaking it costs
/// </summary>
public class Rule
{
    /// <summary>rule id</summary>
    public int Id { get; set; }
    /// <summary>code the rules engine uses, like coffin</summary>
    public string Code { get; set; } = string.Empty;
    /// <summary>short title on the card</summary>
    public string Title { get; set; } = string.Empty;
    /// <summary>the why behind it, shows when the rule is broken</summary>
    public string? Why { get; set; }
    /// <summary>room, general or personal</summary>
    public RuleCategory Category { get; set; }
    /// <summary>tip or suggestion, also its weight in the harmony score</summary>
    public Severity Severity { get; set; }
    /// <summary>the only kind of room it counts for, empty means every room</summary>
    public RoomKind? RoomKind { get; set; }
}
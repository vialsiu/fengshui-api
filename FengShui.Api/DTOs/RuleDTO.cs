//-------a feng shui rule the way it shows on a card
namespace FengShui.Api.DTOs;

/// <summary>
/// a feng shui rule as players see it
/// </summary>
public class RuleDTO
{
    /// <summary>rule id</summary>
    public int Id { get; set; }
    /// <summary>code the rules engine uses, like coffin</summary>
    public string? Code { get; set; }
    /// <summary>short title on the card</summary>
    public string? Title { get; set; }
    /// <summary>the why behind it, shows when the card opens</summary>
    public string? Why { get; set; }
    /// <summary>room, general or personal</summary>
    public string? Category { get; set; }
    /// <summary>suggestion or tip</summary>
    public string? Severity { get; set; }
    /// <summary>which kind of room it's for, empty means every room</summary>
    public string? RoomKind { get; set; }
}
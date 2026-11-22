//---admin only, the check itself lives in code, this is just the wording
namespace FengShui.Api.DTOs;

/// <summary>
/// what the admin sends to add or change a rule's text
/// </summary>
public class RuleCreateDTO
{
    /// <summary>code the rules engine uses, like coffin</summary>
    public string? Code { get; set; }
    /// <summary>short title on the card</summary>
    public string? Title { get; set; }
    /// <summary>the why behind it</summary>
    public string? Why { get; set; }
    /// <summary>room, general or personal</summary>
    public string? Category { get; set; }
    /// <summary>suggestion or tip</summary>
    public string? Severity { get; set; }
    /// <summary>which kind of room it's for, empty means every room</summary>
    public string? RoomKind { get; set; }
}
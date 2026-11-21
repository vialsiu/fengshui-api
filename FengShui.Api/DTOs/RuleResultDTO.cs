//---one rule after the check, kept or broken
namespace FengShui.Api.DTOs;

/// <summary>
/// how one rule came out in a check
/// </summary>
public class RuleResultDTO
{
    /// <summary>rule code, like coffin</summary>
    public string? Code { get; set; }
    /// <summary>short title on the card</summary>
    public string? Title { get; set; }
    /// <summary>the why behind it</summary>
    public string? Why { get; set; }
    /// <summary>2 if the client's concern makes it count double, otherwise 1</summary>
    public int Weight { get; set; }
    /// <summary>furniture codes that break it, empty if it's kept</summary>
    public List<string> Pieces { get; set; } = new List<string>();
}
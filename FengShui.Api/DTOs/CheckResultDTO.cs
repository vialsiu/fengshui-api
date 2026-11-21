//--------what the rules engine gives back
namespace FengShui.Api.DTOs;

/// <summary>
/// the result of checking a layout
/// </summary>
public class CheckResultDTO
{
    /// <summary>0 to 100, 100 means every rule is followed</summary>
    public int Harmony { get; set; }
    /// <summary>rules the layout breaks</summary>
    public List<RuleResultDTO> Broken { get; set; } = new List<RuleResultDTO>();
    /// <summary>rules the layout follows</summary>
    public List<RuleResultDTO> Kept { get; set; } = new List<RuleResultDTO>();
}
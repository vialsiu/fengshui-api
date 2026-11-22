//----the consultation report the client gets at the end
namespace FengShui.Api.DTOs;

/// <summary>
/// what got fixed and what's still broken for a saved layout
/// </summary>
public class ReportDTO
{
    /// <summary>id of the layout the report is about</summary>
    public int LayoutId { get; set; }
    /// <summary>id of the request, empty when it's your own room</summary>
    public int? RequestId { get; set; }
    /// <summary>who asked for the room to be fixed</summary>
    public string? ClientName { get; set; }
    /// <summary>sleep, family, focus or money</summary>
    public string? Concern { get; set; }
    /// <summary>name of the room</summary>
    public string? RoomName { get; set; }
    /// <summary>0 to 100, 100 means every rule is followed</summary>
    public int Harmony { get; set; }
    /// <summary>rules that were broken at the start and are kept now</summary>
    public List<RuleResultDTO> Fixed { get; set; } = new List<RuleResultDTO>();
    /// <summary>rules that are still broken</summary>
    public List<RuleResultDTO> StillBroken { get; set; } = new List<RuleResultDTO>();
}
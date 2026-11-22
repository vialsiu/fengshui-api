//------the consultation report, puts the client, room and check together
namespace FengShui.Api.DTOs;

/// <summary>
/// a consultation report for a saved layout
/// </summary>
public class ReportDTO
{
    /// <summary>id of the layout it's about</summary>
    public int LayoutId { get; set; }
    /// <summary>client's name, empty for your own room</summary>
    public string? ClientName { get; set; }
    /// <summary>client's concern, empty for your own room</summary>
    public string? Concern { get; set; }
    /// <summary>name of the room</summary>
    public string? RoomName { get; set; }
    /// <summary>0 to 100</summary>
    public int Harmony { get; set; }
    /// <summary>rules that were broken in the starting layout and are fixed now</summary>
    public List<string> Fixed { get; set; } = new List<string>();
    /// <summary>rules that are still broken</summary>
    public List<string> StillBroken { get; set; } = new List<string>();
}
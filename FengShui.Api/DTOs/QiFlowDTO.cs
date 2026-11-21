//--------how qi moves through the room from the door
namespace FengShui.Api.DTOs;

/// <summary>
/// the qi flow through a layout
/// </summary>
public class QiFlowDTO
{
    /// <summary>squares from the door to the window, in order</summary>
    public List<SquareDTO> Path { get; set; } = new List<SquareDTO>();
    /// <summary>open squares qi never gets to</summary>
    public List<SquareDTO> Stuck { get; set; } = new List<SquareDTO>();
    /// <summary>false if furniture blocks every way to the window</summary>
    public bool ReachesWindow { get; set; }
}
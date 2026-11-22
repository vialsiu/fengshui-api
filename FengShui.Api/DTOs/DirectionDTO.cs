//----one of the 8 compass directions for a kua number
namespace FengShui.Api.DTOs;

/// <summary>
/// one compass direction and what it means for this kua number
/// </summary>
public class DirectionDTO
{
    /// <summary>N, NE, E, SE, S, SW, W or NW</summary>
    public string? Direction { get; set; }
    /// <summary>the chinese name, like sheng chi</summary>
    public string? Name { get; set; }
    /// <summary>what it's good or bad for, like success</summary>
    public string? Meaning { get; set; }
}
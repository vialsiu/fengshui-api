//-------everything the kua calculator works out
namespace FengShui.Api.DTOs;

/// <summary>
/// a kua number and the directions that go with it
/// </summary>
public class KuaResultDTO
{
    /// <summary>1 to 9, never 5</summary>
    public int Kua { get; set; }
    /// <summary>east or west</summary>
    public string? Group { get; set; }
    /// <summary>water, earth, wood, metal or fire</summary>
    public string? Element { get; set; }
    /// <summary>the 4 good directions, best first</summary>
    public List<DirectionDTO> Good { get; set; } = new List<DirectionDTO>();
    /// <summary>the 4 directions to avoid, worst last</summary>
    public List<DirectionDTO> Bad { get; set; } = new List<DirectionDTO>();
    /// <summary>how it was worked out, one line per step</summary>
    public List<string> Steps { get; set; } = new List<string>();
}
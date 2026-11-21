//---one of the 9 life areas and the box it covers in the room
namespace FengShui.Api.DTOs;

/// <summary>
/// one bagua life area and where it sits in the room
/// </summary>
public class BaguaAreaDTO
{
    /// <summary>wealth, fame, love, family, health, creativity, knowledge, career or helpful people</summary>
    public string? Area { get; set; }
    /// <summary>first column it covers</summary>
    public int FromCol { get; set; }
    /// <summary>last column it covers</summary>
    public int ToCol { get; set; }
    /// <summary>first row it covers</summary>
    public int FromRow { get; set; }
    /// <summary>last row it covers</summary>
    public int ToRow { get; set; }
}
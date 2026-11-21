//--------admin only, adding or changing a client
namespace FengShui.Api.DTOs;

/// <summary>
/// what the admin sends to add or change a client
/// </summary>
public class ClientCreateDTO
{
    /// <summary>client's name</summary>
    public string? Name { get; set; }
    /// <summary>client's age</summary>
    public int Age { get; set; }
    /// <summary>what they said</summary>
    public string? Quote { get; set; }
    /// <summary>sleep, family, focus or money</summary>
    public string? Concern { get; set; }
    /// <summary>what they told the consultant about the room</summary>
    public string? Notes { get; set; }
    /// <summary>used for their personal kua rules</summary>
    public int BirthYear { get; set; }
    /// <summary>female or male</summary>
    public string? KuaFormula { get; set; }
    /// <summary>id of the room to fix</summary>
    public int RoomId { get; set; }
}
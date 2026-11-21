//-----a client card, who they are and what's wrong
namespace FengShui.Api.DTOs;

/// <summary>
/// a client card, who they are and what's bothering them
/// </summary>
public class ClientDTO
{
    /// <summary>client id</summary>
    public int Id { get; set; }
    /// <summary>client's name</summary>
    public string? Name { get; set; }
    /// <summary>client's age</summary>
    public int Age { get; set; }
    /// <summary>what they said, like i can't sleep since i moved in</summary>
    public string? Quote { get; set; }
    /// <summary>sleep, family, focus or money</summary>
    public string? Concern { get; set; }
    /// <summary>what they told the consultant about the room</summary>
    public string? Notes { get; set; }
    /// <summary>id of the room to fix</summary>
    public int RoomId { get; set; }
    /// <summary>name of the room to fix</summary>
    public string? RoomName { get; set; }
}
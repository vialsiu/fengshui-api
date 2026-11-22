//----someone playing the game, they get an api key when they sign up
namespace FengShui.Api.Models;

/// <summary>
/// a player, their own rooms and the layouts they've saved
/// </summary>
public class Player
{
    /// <summary>player id</summary>
    public int Id { get; set; }
    /// <summary>the name they go by</summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>birth year if they gave one, for their kua number</summary>
    public int? BirthYear { get; set; }
    /// <summary>female or male if they gave one</summary>
    public KuaFormula? KuaFormula { get; set; }
    /// <summary>the key they send in the X-Api-Key header</summary>
    public string ApiKey { get; set; } = string.Empty;

    //------one player has many rooms they made themselves
    /// <summary>rooms this player made</summary>
    public ICollection<Room>? Rooms { get; set; } = new List<Room>();
    //---one player has many saved layouts
    /// <summary>layouts this player saved</summary>
    public ICollection<Layout>? Layouts { get; set; } = new List<Layout>();
}

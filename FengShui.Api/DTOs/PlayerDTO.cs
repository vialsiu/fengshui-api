//---a player the way the api hands it back
namespace FengShui.Api.DTOs;

/// <summary>
/// a player as the api returns them
/// </summary>
public class PlayerDTO
{
    /// <summary>player id</summary>
    public int Id { get; set; }
    /// <summary>the name they go by</summary>
    public string? Name { get; set; }
    /// <summary>birth year if they gave one</summary>
    public int? BirthYear { get; set; }
    /// <summary>female or male if they gave one</summary>
    public string? KuaFormula { get; set; }
    /// <summary>only shown once right after signing up, goes in the X-Api-Key header</summary>
    public string? ApiKey { get; set; }
}
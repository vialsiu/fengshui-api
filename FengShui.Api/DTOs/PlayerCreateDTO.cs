//------what someone sends when they sign up
namespace FengShui.Api.DTOs;

/// <summary>
/// what a new player sends to register
/// </summary>
public class PlayerCreateDTO
{
    /// <summary>the name they go by</summary>
    public string? Name { get; set; }
    /// <summary>optional, used for their kua number</summary>
    public int? BirthYear { get; set; }
    /// <summary>optional, female or male (the two kua formulas)</summary>
    public string? KuaFormula { get; set; }
}
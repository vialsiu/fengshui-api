//---what the admin sends to add or change a client
namespace FengShui.Api.DTOs;

/// <summary>
/// a new client, the birth year is kept so their kua number can be worked out
/// </summary>
public class ClientCreateDTO
{
    /// <summary>their name</summary>
    public string? Name { get; set; }
    /// <summary>how old they are</summary>
    public int Age { get; set; }
    /// <summary>year they were born, for the kua number</summary>
    public int BirthYear { get; set; }
    /// <summary>male or female, the kua formula is different for each</summary>
    public string? KuaFormula { get; set; }
}
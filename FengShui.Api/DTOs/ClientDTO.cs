//-------a client card, what they want fixed lives on their requests now
namespace FengShui.Api.DTOs;

/// <summary>
/// a client, the person behind one or more requests
/// </summary>
public class ClientDTO
{
    /// <summary>client id</summary>
    public int Id { get; set; }
    /// <summary>their name</summary>
    public string? Name { get; set; }
    /// <summary>how old they are</summary>
    public int Age { get; set; }
    /// <summary>how many rooms they've asked to have fixed</summary>
    public int RequestCount { get; set; }
}
//---a client, the person behind one or more requests
namespace FengShui.Api.Models;

/// <summary>
/// a client, their birth details are kept for their kua number
/// </summary>
public class Client
{
    /// <summary>client id</summary>
    public int Id { get; set; }
    /// <summary>their name</summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>how old they are</summary>
    public int Age { get; set; }
    /// <summary>year they were born</summary>
    public int BirthYear { get; set; }
    /// <summary>female or male</summary>
    public KuaFormula KuaFormula { get; set; }

    //------one client can ask for one or two rooms to be fixed
    /// <summary>the rooms they've asked to have fixed</summary>
    public ICollection<Request>? Requests { get; set; } = new List<Request>();
}

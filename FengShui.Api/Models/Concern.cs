//---what's bothering the client, decides which rules matter most for them
namespace FengShui.Api.Models;

/// <summary>
/// the four things a client can be worried about
/// </summary>
public enum Concern
{
    /// <summary>can't sleep properly</summary>
    Sleep,
    /// <summary>arguing, or family feels distant</summary>
    Family,
    /// <summary>can't concentrate</summary>
    Focus,
    /// <summary>money keeps slipping away</summary>
    Money
}

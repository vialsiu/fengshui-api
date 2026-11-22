//----how bad it is to break a rule, the number is how much harmony it costs
namespace FengShui.Api.Models;

/// <summary>
/// how strong a rule is, the value is its weight in the harmony score
/// </summary>
public enum Severity
{
    /// <summary>nice to have, costs a little harmony</summary>
    Tip = 1,
    /// <summary>should really be followed, costs more harmony</summary>
    Suggestion = 3
}
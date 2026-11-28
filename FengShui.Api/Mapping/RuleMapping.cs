//----rules between the database and the api
using FengShui.Api.DTOs;
using FengShui.Api.Models;

namespace FengShui.Api.Mapping;

/// <summary>
/// model to dto and dto to model for rules
/// </summary>
public static class RuleMapping
{
    /// <summary>
    /// the dto for a stored rule
    /// </summary>
    /// <param name="rule">the stored rule</param>
    /// <returns>the dto</returns>
    public static RuleDTO ToDto(this Rule rule)
    {
        return new RuleDTO
        {
            Id = rule.Id,
            Code = rule.Code,
            Title = rule.Title,
            Why = rule.Why,
            Category = rule.Category.ToText(),
            Severity = rule.Severity.ToText(),
            RoomKind = rule.RoomKind?.ToText()
        };
    }

    /// <summary>
    /// copies what the admin sent onto a rule, only call this after it's been validated
    /// </summary>
    /// <param name="dto">what was sent</param>
    /// <param name="target">the rule to fill in, new or existing</param>
    public static void CopyTo(this RuleCreateDTO dto, Rule target)
    {
        target.Code = dto.Code!.Trim();
        target.Title = dto.Title!.Trim();
        //------an empty why is saved as nothing instead of an empty string
        target.Why = string.IsNullOrWhiteSpace(dto.Why) ? null : dto.Why.Trim();
        EnumText.TryParse<RuleCategory>(dto.Category, out var category);
        target.Category = category;
        EnumText.TryParse<Severity>(dto.Severity, out var severity);
        target.Severity = severity;
        target.RoomKind = EnumText.TryParse<RoomKind>(dto.RoomKind, out var kind) ? kind : null;
    }
}
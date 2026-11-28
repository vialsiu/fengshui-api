//---checks a rule's wording before it's saved
using FengShui.Api.DTOs;
using FengShui.Api.Mapping;
using FengShui.Api.Models;
using FengShui.Api.RulesEngine;

namespace FengShui.Api.Validation;

/// <summary>
/// rules for a valid rule
/// </summary>
public static class RuleValidator
{
    /// <summary>longest title, it has to fit on a card</summary>
    public const int MaxTitleLength = 60;

    /// <summary>
    /// checks what the admin sent
    /// </summary>
    /// <param name="dto">the rule</param>
    /// <returns>what's wrong, or null if it's fine</returns>
    public static string? Validate(RuleCreateDTO dto)
    {
        //-----the wording is only useful if the rules engine has a check with that code
        if (string.IsNullOrWhiteSpace(dto.Code) || !RuleCodes.All.Contains(dto.Code.Trim()))
            return $"the code has to be one the rules engine knows: {string.Join(", ", RuleCodes.All)}";

        if (string.IsNullOrWhiteSpace(dto.Title))
            return "the title can't be empty";
        if (dto.Title.Trim().Length > MaxTitleLength)
            return $"the title can be at most {MaxTitleLength} characters";

        if (!EnumText.TryParse<RuleCategory>(dto.Category, out var category))
            return $"the category has to be one of: {EnumText.Options<RuleCategory>()}";

        if (!EnumText.TryParse<Severity>(dto.Severity, out _))
            return $"the severity has to be one of: {EnumText.Options<Severity>()}";

        var hasKind = !string.IsNullOrWhiteSpace(dto.RoomKind);
        if (hasKind && !EnumText.TryParse<RoomKind>(dto.RoomKind, out _))
            return $"the room kind has to be one of: {EnumText.Options<RoomKind>()}, or empty for every room";

        //----a room rule is about one kind of room, so it needs to say which
        if (category == RuleCategory.Room && !hasKind)
            return "a room rule needs a room kind";

        return null;
    }
}
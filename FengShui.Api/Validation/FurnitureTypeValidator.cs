//-----checks a furniture type before it's saved, the controller just sends back what this says
using System.Text.RegularExpressions;
using FengShui.Api.DTOs;
using FengShui.Api.Mapping;
using FengShui.Api.Models;

namespace FengShui.Api.Validation;

/// <summary>
/// rules for a valid furniture type
/// </summary>
public static class FurnitureTypeValidator
{
    /// <summary>biggest width or depth in half-squares, 40 is 10 metres</summary>
    public const int MaxSize = 40;

    //---lowercase, starts with a letter, like single_bed
    //------ref https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference
    private static readonly Regex CodePattern = new("^[a-z][a-z0-9_]{1,29}$");

    /// <summary>
    /// checks what the admin sent
    /// </summary>
    /// <param name="dto">the furniture type</param>
    /// <returns>what's wrong, or null if it's fine</returns>
    public static string? Validate(FurnitureTypeCreateDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Code) || !CodePattern.IsMatch(dto.Code.Trim()))
            return "the code has to be 2 to 30 lowercase letters, numbers or underscores, starting with a letter, like single_bed";

        if (string.IsNullOrWhiteSpace(dto.Name))
            return "the name can't be empty";

        if (dto.Width < 1 || dto.Width > MaxSize || dto.Height < 1 || dto.Height > MaxSize)
            return $"width and height have to be between 1 and {MaxSize} half-squares";

        if (!string.IsNullOrWhiteSpace(dto.Element) && !EnumText.TryParse<Element>(dto.Element, out _))
            return $"the element has to be one of: {EnumText.Options<Element>()}";

        return null;
    }
}
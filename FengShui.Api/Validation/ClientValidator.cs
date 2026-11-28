//--------checks a client before they're saved
using FengShui.Api.DTOs;
using FengShui.Api.Mapping;
using FengShui.Api.Models;

namespace FengShui.Api.Validation;

/// <summary>
/// rules for a valid client
/// </summary>
public static class ClientValidator
{
    /// <summary>longest name, it has to fit on a client card</summary>
    public const int MaxNameLength = 40;

    /// <summary>
    /// checks what the admin sent
    /// </summary>
    /// <param name="dto">the client</param>
    /// <returns>what's wrong, or null if it's fine</returns>
    public static string? Validate(ClientCreateDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            return "the name can't be empty";
        if (dto.Name.Trim().Length > MaxNameLength)
            return $"the name can be at most {MaxNameLength} characters";

        var thisYear = DateTime.UtcNow.Year;
        if (dto.BirthYear < 1900 || dto.BirthYear > thisYear)
            return $"the birth year has to be between 1900 and {thisYear}";

        if (dto.Age < 1 || dto.Age > 120)
            return "the age has to be between 1 and 120";

        //----someone born in 1992 is 33 or 34 this year depending on their birthday, anything else is a typo
        var expected = thisYear - dto.BirthYear;
        if (dto.Age != expected && dto.Age != expected - 1)
            return $"someone born in {dto.BirthYear} would be {expected - 1} or {expected}, not {dto.Age}";

        if (!EnumText.TryParse<KuaFormula>(dto.KuaFormula, out _))
            return $"the kua formula has to be one of: {EnumText.Options<KuaFormula>()}";

        return null;
    }
}
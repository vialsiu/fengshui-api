//------enums go in and out of the api as lowercase text, like "wood" or "bedroom"
namespace FengShui.Api.Mapping;

/// <summary>
/// turns enums into text and back, only accepting the real names
/// </summary>
public static class EnumText
{
    /// <summary>
    /// reads text like "Wood" or "wood" into the enum, numbers like "1" are not allowed
    /// </summary>
    /// <typeparam name="TEnum">the enum, like Element</typeparam>
    /// <param name="text">what was sent</param>
    /// <param name="value">the enum value if it worked</param>
    /// <returns>true if the text is one of the enum's names</returns>
    //---ref https://learn.microsoft.com/en-us/dotnet/api/system.enum.getnames
    public static bool TryParse<TEnum>(string? text, out TEnum value) where TEnum : struct, Enum
    {
        value = default;
        if (string.IsNullOrWhiteSpace(text))
            return false;

        //-----matching on the names means "1" or "0" can't sneak through as a value
        var name = Enum.GetNames<TEnum>()
            .FirstOrDefault(n => n.Equals(text.Trim(), StringComparison.OrdinalIgnoreCase));
        if (name == null)
            return false;

        value = Enum.Parse<TEnum>(name);
        return true;
    }

    /// <summary>
    /// the enum as lowercase text, the way the api sends it
    /// </summary>
    /// <param name="value">the enum value</param>
    /// <returns>like "wood"</returns>
    public static string ToText(this Enum value)
    {
        return value.ToString().ToLowerInvariant();
    }

    /// <summary>
    /// every allowed value, for error messages
    /// </summary>
    /// <typeparam name="TEnum">the enum</typeparam>
    /// <returns>like "wood, fire, earth, metal, water"</returns>
    public static string Options<TEnum>() where TEnum : struct, Enum
    {
        return string.Join(", ", Enum.GetNames<TEnum>().Select(n => n.ToLowerInvariant()));
    }
}
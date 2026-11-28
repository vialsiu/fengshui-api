//-----checks a request before it's saved, the controller checks the client, room and furniture exist
using FengShui.Api.DTOs;
using FengShui.Api.Mapping;
using FengShui.Api.Models;

namespace FengShui.Api.Validation;

/// <summary>
/// rules for a valid request
/// </summary>
public static class RequestValidator
{
    /// <summary>longest quote, it has to fit on the client card</summary>
    public const int MaxQuoteLength = 200;
    /// <summary>longest note</summary>
    public const int MaxNoteLength = 300;
    /// <summary>most of one kind of furniture a client can own</summary>
    public const int MaxOwned = 10;

    /// <summary>
    /// checks what the admin sent
    /// </summary>
    /// <param name="dto">the request</param>
    /// <returns>what's wrong, or null if it's fine</returns>
    public static string? Validate(RequestCreateDTO dto)
    {
        if (dto.ClientId < 1 || dto.RoomId < 1)
            return "the request needs a client id and a room id";

        if (!EnumText.TryParse<Concern>(dto.Concern, out _))
            return $"the concern has to be one of: {EnumText.Options<Concern>()}";

        if (string.IsNullOrWhiteSpace(dto.Quote))
            return "the quote can't be empty, it's what the client says is wrong";
        if (dto.Quote.Trim().Length > MaxQuoteLength)
            return $"the quote can be at most {MaxQuoteLength} characters";
        if (dto.Note != null && dto.Note.Trim().Length > MaxNoteLength)
            return $"the note can be at most {MaxNoteLength} characters";

        //---a room with nothing to place in it isn't much of a puzzle
        if (dto.Inventory.Count == 0)
            return "the client has to own at least one piece of furniture";

        foreach (var item in dto.Inventory)
        {
            if (string.IsNullOrWhiteSpace(item.Furniture))
                return "every inventory line needs a furniture code";
            if (item.Owned < 1 || item.Owned > MaxOwned)
                return $"owned has to be between 1 and {MaxOwned}, {item.Furniture} has {item.Owned}";
        }

        //-------one line per kind of furniture, "2 beds" not "bed, bed"
        var repeated = dto.Inventory
            .GroupBy(i => i.Furniture!.Trim())
            .FirstOrDefault(g => g.Count() > 1);
        if (repeated != null)
            return $"{repeated.Key} is listed more than once, put the total in one line instead";

        return null;
    }
}
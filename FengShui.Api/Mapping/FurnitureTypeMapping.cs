//---furniture types between the database and the api
using FengShui.Api.DTOs;
using FengShui.Api.Models;

namespace FengShui.Api.Mapping;

/// <summary>
/// model to dto and dto to model for furniture types
/// </summary>
public static class FurnitureTypeMapping
{
    /// <summary>
    /// the dto for a stored furniture type
    /// </summary>
    /// <param name="furniture">the stored type</param>
    /// <returns>the dto</returns>
    public static FurnitureTypeDTO ToDto(this FurnitureType furniture)
    {
        return new FurnitureTypeDTO
        {
            Id = furniture.Id,
            Code = furniture.Code,
            Name = furniture.Name,
            Width = furniture.Width,
            Height = furniture.Height,
            IsFlat = furniture.IsFlat,
            Element = furniture.Element?.ToText()
        };
    }

    /// <summary>
    /// copies what the admin sent onto a furniture type, only call this after it's been validated
    /// </summary>
    /// <param name="dto">what was sent</param>
    /// <param name="target">the type to fill in, new or existing</param>
    public static void CopyTo(this FurnitureTypeCreateDTO dto, FurnitureType target)
    {
        target.Code = dto.Code!.Trim();
        target.Name = dto.Name!.Trim();
        target.Width = dto.Width;
        target.Height = dto.Height;
        target.IsFlat = dto.IsFlat;
        //-------no element is allowed, some furniture doesn't have one
        target.Element = EnumText.TryParse<Element>(dto.Element, out var element) ? element : null;
    }
}
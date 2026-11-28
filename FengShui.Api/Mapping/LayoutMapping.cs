//---layouts and their pieces between the database and the api
using FengShui.Api.DTOs;
using FengShui.Api.Models;

namespace FengShui.Api.Mapping;

/// <summary>
/// model to dto for layouts and placements
/// </summary>
public static class LayoutMapping
{
    /// <summary>
    /// one piece, sent with its furniture code instead of the database id
    /// </summary>
    /// <param name="placement">the stored piece, with its furniture type loaded</param>
    /// <returns>the dto</returns>
    public static PlacementDTO ToDto(this Placement placement)
    {
        return new PlacementDTO
        {
            Furniture = placement.FurnitureType?.Code,
            Col = placement.Col,
            Row = placement.Row,
            Rotation = placement.Rotation
        };
    }

    /// <summary>
    /// a whole layout with every piece
    /// </summary>
    /// <param name="layout">the stored layout, with its placements loaded</param>
    /// <returns>the dto</returns>
    public static LayoutDTO ToDto(this Layout layout)
    {
        return new LayoutDTO
        {
            Id = layout.Id,
            Kind = layout.Kind.ToText(),
            Name = layout.Name,
            RoomId = layout.RoomId,
            RequestId = layout.RequestId,
            //------same order every time so the room draws the same way
            Placements = (layout.Placements ?? new List<Placement>())
                .OrderBy(p => p.Id)
                .Select(p => p.ToDto())
                .ToList(),
            UpdatedAt = layout.UpdatedAt
        };
    }
}
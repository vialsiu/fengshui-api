//--------turns a stored player into the dto the api sends back
using FengShui.Api.DTOs;
using FengShui.Api.Models;

namespace FengShui.Api.Mapping;

/// <summary>
/// model to dto for players
/// </summary>
public static class PlayerMapping
{
    /// <summary>
    /// the dto for a player, the api key is left out unless asked for
    /// </summary>
    /// <param name="player">the stored player</param>
    /// <param name="withKey">true only right after signing up</param>
    /// <returns>the dto</returns>
    public static PlayerDTO ToDto(this Player player, bool withKey = false)
    {
        return new PlayerDTO
        {
            Id = player.Id,
            Name = player.Name,
            BirthYear = player.BirthYear,
            //---the enum goes out as lowercase text, like "female"
            KuaFormula = player.KuaFormula?.ToString().ToLowerInvariant(),
            ApiKey = withKey ? player.ApiKey : null
        };
    }
}
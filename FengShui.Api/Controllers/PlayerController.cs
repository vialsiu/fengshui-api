//----players sign up here and get their api key
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FengShui.Api.Auth;
using FengShui.Api.DTOs;
using FengShui.Api.Mapping;
using FengShui.Api.Models;
using FengShui.Api.Repositories;

namespace FengShui.Api.Controllers
{
    /// <summary>
    /// signing up and your own player details
    /// </summary>
    /// <param name="players">where players are stored</param>
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController(IPlayerRepository players) : ControllerBase
    {
        //------names longer than this would break the layout of the game's header
        private const int MaxNameLength = 40;

        /// <summary>
        /// sign up as a new player and get an api key back
        /// </summary>
        /// <param name="player">name, and optionally birth year and kua formula</param>
        /// <returns>the new player with their api key</returns>
        /// <response code="201">player made, the api key is only shown this once</response>
        /// <response code="400">the name is empty, or the birth year or kua formula isn't valid</response>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<PlayerDTO>> PostPlayer(PlayerCreateDTO player)
        {
            var name = player.Name?.Trim();
            if (string.IsNullOrEmpty(name))
                return BadRequest("the name can't be empty");
            if (name.Length > MaxNameLength)
                return BadRequest($"the name can be at most {MaxNameLength} characters");

            if (player.BirthYear is int year && (year < 1900 || year > DateTime.UtcNow.Year))
                return BadRequest($"the birth year has to be between 1900 and {DateTime.UtcNow.Year}");

            KuaFormula? formula = null;
            if (!string.IsNullOrWhiteSpace(player.KuaFormula))
            {
                //----TryParse would also accept "1", so IsDefined makes sure it's really female or male
                if (!Enum.TryParse<KuaFormula>(player.KuaFormula, true, out var parsed) || !Enum.IsDefined(parsed))
                    return BadRequest("the kua formula has to be female or male");
                formula = parsed;
            }

            var saved = await players.AddAsync(new Player
            {
                Name = name,
                BirthYear = player.BirthYear,
                KuaFormula = formula,
                ApiKey = ApiKeyGenerator.NewKey()
            });

            //---the only time the key is ever sent back
            return CreatedAtAction(nameof(GetPlayer), new { id = saved.Id }, saved.ToDto(withKey: true));
        }

        /// <summary>
        /// get your own player details
        /// </summary>
        /// <param name="id">player id</param>
        /// <returns>the player, without the api key</returns>
        /// <response code="200">found it</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">that's someone else's player</response>
        /// <response code="404">no player with that id</response>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<PlayerDTO>> GetPlayer(int id)
        {
            //-------players can only see themselves, the admin can see anyone
            if (!User.IsAdmin() && User.GetPlayerId() != id)
                return Forbid();

            var player = await players.GetByIdAsync(id);
            if (player == null)
                return NotFound();

            return player.ToDto();
        }
    }
}
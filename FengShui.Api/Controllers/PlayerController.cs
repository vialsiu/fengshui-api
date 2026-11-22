//----players sign up here and get their api key
using Microsoft.AspNetCore.Mvc;
using FengShui.Api.DTOs;

namespace FengShui.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        /// <summary>
        /// sign up as a new player and get an api key back
        /// </summary>
        /// <param name="player">name, and optionally birth year and kua formula</param>
        /// <returns>the new player with their api key</returns>
        /// <response code="201">player made, the api key is only shown this once</response>
        /// <response code="400">the name is empty</response>
        [HttpPost]
        public ActionResult<PlayerDTO> PostPlayer(PlayerCreateDTO player)
        {
            //---only the design for now, filled in on feature/players
            return StatusCode(501);
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
        public ActionResult<PlayerDTO> GetPlayer(int id)
        {
            //-----only the design for now, filled in on feature/players
            return StatusCode(501);
        }
    }
}
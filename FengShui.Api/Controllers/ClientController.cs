//------the clients and their concerns, players read them, the admin manages them
using Microsoft.AspNetCore.Mvc;
using FengShui.Api.DTOs;

namespace FengShui.Api.Controllers
{
    /// <summary>
    /// the clients and what's bothering them
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        /// <summary>
        /// see every client and what's bothering them
        /// </summary>
        /// <returns>all the client cards</returns>
        /// <response code="200">the list, can be empty</response>
        /// <response code="401">no api key sent</response>
        [HttpGet]
        public ActionResult<IEnumerable<ClientDTO>> GetClients()
        {
            //---only the design for now, filled in on feature/clients
            return StatusCode(501);
        }

        /// <summary>
        /// see one client
        /// </summary>
        /// <param name="id">client id</param>
        /// <returns>the client card</returns>
        /// <response code="200">found them</response>
        /// <response code="401">no api key sent</response>
        /// <response code="404">no client with that id</response>
        [HttpGet("{id}")]
        public ActionResult<ClientDTO> GetClient(int id)
        {
            //--------only the design for now, filled in on feature/clients
            return StatusCode(501);
        }

        /// <summary>
        /// add a client (admin only)
        /// </summary>
        /// <param name="client">the new client</param>
        /// <returns>the client that was made</returns>
        /// <response code="201">client made</response>
        /// <response code="400">missing name or quote, or the room doesn't exist</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        [HttpPost]
        public ActionResult<ClientDTO> PostClient(ClientCreateDTO client)
        {
            //----only the design for now, filled in on feature/clients
            return StatusCode(501);
        }

        /// <summary>
        /// change a client (admin only)
        /// </summary>
        /// <param name="id">client id</param>
        /// <param name="client">the new details</param>
        /// <response code="204">changed</response>
        /// <response code="400">missing name or quote, or the room doesn't exist</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        /// <response code="404">no client with that id</response>
        [HttpPut("{id}")]
        public IActionResult PutClient(int id, ClientCreateDTO client)
        {
            //------only the design for now, filled in on feature/clients
            return StatusCode(501);
        }

        /// <summary>
        /// remove a client (admin only)
        /// </summary>
        /// <param name="id">client id</param>
        /// <response code="204">removed</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        /// <response code="404">no client with that id</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            //---only the design for now, filled in on feature/clients
            return StatusCode(501);
        }
    }
}
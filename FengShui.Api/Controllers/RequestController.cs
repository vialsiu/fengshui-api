//------the list of jobs, each client asking for a room to be fixed
using Microsoft.AspNetCore.Mvc;
using FengShui.Api.DTOs;

namespace FengShui.Api.Controllers
{
    /// <summary>
    /// requests from clients to fix a room, with what they own and their starting layout
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        /// <summary>
        /// see every request, the first screen of the game
        /// </summary>
        /// <returns>all the requests with who's asking and which room</returns>
        /// <response code="200">the list, can be empty</response>
        /// <response code="401">no api key sent</response>
        [HttpGet]
        public ActionResult<IEnumerable<RequestDTO>> GetRequests()
        {
            //---only the design for now, filled in on feature/requests
            return StatusCode(501);
        }

        /// <summary>
        /// see one request, the client's note and everything they own for that room
        /// </summary>
        /// <param name="id">request id</param>
        /// <returns>the request with its furniture inventory</returns>
        /// <response code="200">found it</response>
        /// <response code="401">no api key sent</response>
        /// <response code="404">no request with that id</response>
        [HttpGet("{id}")]
        public ActionResult<RequestDTO> GetRequest(int id)
        {
            //-------only the design for now, filled in on feature/requests
            return StatusCode(501);
        }

        /// <summary>
        /// get how the room looks when you arrive, whatever the client left in it
        /// </summary>
        /// <param name="id">request id</param>
        /// <returns>the starting layout with every piece still in the room</returns>
        /// <response code="200">found it, can have no pieces if they cleared the room</response>
        /// <response code="401">no api key sent</response>
        /// <response code="404">no request with that id</response>
        [HttpGet("{id}/layouts/start")]
        public ActionResult<LayoutDTO> GetStartLayout(int id)
        {
            //----only the design for now, filled in on feature/requests
            return StatusCode(501);
        }

        /// <summary>
        /// add a request (admin only)
        /// </summary>
        /// <param name="request">who's asking, which room, their note and what they own</param>
        /// <returns>the request that was made</returns>
        /// <response code="201">made</response>
        /// <response code="400">the client or room doesn't exist, an owned count is under 1, or a furniture code doesn't exist</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        [HttpPost]
        public ActionResult<RequestDTO> PostRequest(RequestCreateDTO request)
        {
            //--only the design for now, filled in on feature/requests
            return StatusCode(501);
        }

        /// <summary>
        /// change a request (admin only)
        /// </summary>
        /// <param name="id">request id</param>
        /// <param name="request">the new details</param>
        /// <response code="204">changed</response>
        /// <response code="400">the client or room doesn't exist, an owned count is under 1, or a furniture code doesn't exist</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        /// <response code="404">no request with that id</response>
        [HttpPut("{id}")]
        public IActionResult PutRequest(int id, RequestCreateDTO request)
        {
            //------only the design for now, filled in on feature/requests
            return StatusCode(501);
        }

        /// <summary>
        /// remove a request (admin only)
        /// </summary>
        /// <param name="id">request id</param>
        /// <response code="204">removed</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        /// <response code="404">no request with that id</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteRequest(int id)
        {
            //---only the design for now, filled in on feature/requests
            return StatusCode(501);
        }
    }
}
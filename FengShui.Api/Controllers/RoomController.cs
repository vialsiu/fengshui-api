//-------the game's rooms plus the ones players make for themselves
using Microsoft.AspNetCore.Mvc;
using FengShui.Api.DTOs;

namespace FengShui.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        /// <summary>
        /// see the rooms, or only your own ones
        /// </summary>
        /// <param name="mine">true to only get rooms you made</param>
        /// <returns>the rooms</returns>
        /// <response code="200">the list, can be empty</response>
        /// <response code="401">no api key sent</response>
        [HttpGet]
        public ActionResult<IEnumerable<RoomDTO>> GetRooms(bool mine)
        {
            //----only the design for now, filled in on feature/rooms
            return StatusCode(501);
        }

        /// <summary>
        /// see one room, its size, door, window and which way is north
        /// </summary>
        /// <param name="id">room id</param>
        /// <returns>the room</returns>
        /// <response code="200">found it</response>
        /// <response code="401">no api key sent</response>
        /// <response code="404">no room with that id</response>
        [HttpGet("{id}")]
        public ActionResult<RoomDTO> GetRoom(int id)
        {
            //---only the design for now, filled in on feature/rooms
            return StatusCode(501);
        }

        /// <summary>
        /// get the messy starting layout for a room, so a consultation can begin
        /// </summary>
        /// <param name="id">room id</param>
        /// <returns>the starting layout with every piece</returns>
        /// <response code="200">found it</response>
        /// <response code="401">no api key sent</response>
        /// <response code="404">no room with that id, or it has no starting layout</response>
        [HttpGet("{id}/layouts/start")]
        public ActionResult<LayoutDTO> GetStartLayout(int id)
        {
            //------only the design for now, filled in on feature/layouts
            return StatusCode(501);
        }

        /// <summary>
        /// get the bagua map for a room, the 9 life areas and where each one sits
        /// </summary>
        /// <param name="id">room id</param>
        /// <returns>the 9 areas, turned to match the door wall</returns>
        /// <response code="200">the 9 areas</response>
        /// <response code="401">no api key sent</response>
        /// <response code="404">no room with that id</response>
        [HttpGet("{id}/bagua")]
        public ActionResult<IEnumerable<BaguaAreaDTO>> GetBagua(int id)
        {
            //--------only the design for now, filled in on feature/bagua
            return StatusCode(501);
        }

        /// <summary>
        /// make your own room from its real measurements
        /// </summary>
        /// <param name="room">size, door, window and north wall</param>
        /// <returns>the room that was made</returns>
        /// <response code="201">room made and it's yours</response>
        /// <response code="400">size out of range, or the door or window doesn't fit on its wall</response>
        /// <response code="401">no api key sent</response>
        [HttpPost]
        public ActionResult<RoomDTO> PostRoom(RoomCreateDTO room)
        {
            //---only the design for now, filled in on feature/rooms
            return StatusCode(501);
        }

        /// <summary>
        /// change one of your own rooms
        /// </summary>
        /// <param name="id">room id</param>
        /// <param name="room">the new details</param>
        /// <response code="204">changed</response>
        /// <response code="400">size out of range, or the door or window doesn't fit on its wall</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">it's not your room</response>
        /// <response code="404">no room with that id</response>
        [HttpPut("{id}")]
        public IActionResult PutRoom(int id, RoomUpdateDTO room)
        {
            //-----only the design for now, filled in on feature/rooms
            return StatusCode(501);
        }

        /// <summary>
        /// delete one of your own rooms
        /// </summary>
        /// <param name="id">room id</param>
        /// <response code="204">deleted</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">it's not your room</response>
        /// <response code="404">no room with that id</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            //----only the design for now, filled in on feature/rooms
            return StatusCode(501);
        }
    }
}
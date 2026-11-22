//---the kinds of furniture, everyone can read them, only the admin changes them
using Microsoft.AspNetCore.Mvc;
using FengShui.Api.DTOs;

namespace FengShui.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnitureTypeController : ControllerBase
    {
        /// <summary>
        /// see every kind of furniture
        /// </summary>
        /// <returns>all furniture types</returns>
        /// <response code="200">the list</response>
        /// <response code="401">no api key sent</response>
        [HttpGet]
        public ActionResult<IEnumerable<FurnitureTypeDTO>> GetFurnitureTypes()
        {
            //------only the design for now, filled in on feature/furniture
            return StatusCode(501);
        }

        /// <summary>
        /// see one kind of furniture
        /// </summary>
        /// <param name="id">furniture type id</param>
        /// <returns>the furniture type</returns>
        /// <response code="200">found it</response>
        /// <response code="401">no api key sent</response>
        /// <response code="404">no furniture type with that id</response>
        [HttpGet("{id}")]
        public ActionResult<FurnitureTypeDTO> GetFurnitureType(int id)
        {
            //---only the design for now, filled in on feature/furniture
            return StatusCode(501);
        }

        /// <summary>
        /// add a kind of furniture (admin only)
        /// </summary>
        /// <param name="furnitureType">the new furniture type</param>
        /// <returns>the furniture type that was made</returns>
        /// <response code="201">made</response>
        /// <response code="400">missing code or name, size under 1, unknown element, or the code is taken</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        [HttpPost]
        public ActionResult<FurnitureTypeDTO> PostFurnitureType(FurnitureTypeCreateDTO furnitureType)
        {
            //-------only the design for now, filled in on feature/furniture
            return StatusCode(501);
        }

        /// <summary>
        /// change a kind of furniture (admin only)
        /// </summary>
        /// <param name="id">furniture type id</param>
        /// <param name="furnitureType">the new details</param>
        /// <response code="204">changed</response>
        /// <response code="400">missing code or name, size under 1, or unknown element</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        /// <response code="404">no furniture type with that id</response>
        [HttpPut("{id}")]
        public IActionResult PutFurnitureType(int id, FurnitureTypeCreateDTO furnitureType)
        {
            //----only the design for now, filled in on feature/furniture
            return StatusCode(501);
        }

        /// <summary>
        /// remove a kind of furniture (admin only)
        /// </summary>
        /// <param name="id">furniture type id</param>
        /// <response code="204">removed</response>
        /// <response code="400">it's still used in a layout</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        /// <response code="404">no furniture type with that id</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteFurnitureType(int id)
        {
            //-----only the design for now, filled in on feature/furniture
            return StatusCode(501);
        }
    }
}
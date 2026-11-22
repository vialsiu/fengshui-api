//-----saving, checking and reporting on layouts, the heart of the game
using Microsoft.AspNetCore.Mvc;
using FengShui.Api.DTOs;

namespace FengShui.Api.Controllers
{
    /// <summary>
    /// saving, checking, qi flow and reports for layouts
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LayoutController : ControllerBase
    {
        /// <summary>
        /// see every layout you've saved
        /// </summary>
        /// <returns>your layouts</returns>
        /// <response code="200">the list, can be empty</response>
        /// <response code="401">no api key sent</response>
        [HttpGet]
        public ActionResult<IEnumerable<LayoutDTO>> GetLayouts()
        {
            //---only the design for now, filled in on feature/layouts
            return StatusCode(501);
        }

        /// <summary>
        /// see one of your saved layouts
        /// </summary>
        /// <param name="id">layout id</param>
        /// <returns>the layout with every piece</returns>
        /// <response code="200">found it</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">it's someone else's layout</response>
        /// <response code="404">no layout with that id</response>
        [HttpGet("{id}")]
        public ActionResult<LayoutDTO> GetLayout(int id)
        {
            //------only the design for now, filled in on feature/layouts
            return StatusCode(501);
        }

        /// <summary>
        /// save a new layout for a request or your own room
        /// </summary>
        /// <param name="layout">the room, the request if there is one, and every piece</param>
        /// <returns>the saved layout</returns>
        /// <response code="201">saved against your player</response>
        /// <response code="400">two pieces overlap, a piece is outside the room, a furniture code doesn't exist, or there's more of a piece than the client owns</response>
        /// <response code="401">no api key sent</response>
        /// <response code="404">the room or request doesn't exist</response>
        [HttpPost]
        public ActionResult<LayoutDTO> PostLayout(LayoutCreateDTO layout)
        {
            //----only the design for now, filled in on feature/layouts
            return StatusCode(501);
        }

        /// <summary>
        /// change one of your saved layouts
        /// </summary>
        /// <param name="id">layout id</param>
        /// <param name="layout">the new name and pieces</param>
        /// <response code="204">changed</response>
        /// <response code="400">two pieces overlap, a piece is outside the room, a furniture code doesn't exist, or there's more of a piece than the client owns</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">it's someone else's layout</response>
        /// <response code="404">no layout with that id</response>
        [HttpPut("{id}")]
        public IActionResult PutLayout(int id, LayoutUpdateDTO layout)
        {
            //--------only the design for now, filled in on feature/layouts
            return StatusCode(501);
        }

        /// <summary>
        /// delete one of your saved layouts
        /// </summary>
        /// <param name="id">layout id</param>
        /// <response code="204">deleted</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">it's someone else's layout</response>
        /// <response code="404">no layout with that id</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteLayout(int id)
        {
            //---only the design for now, filled in on feature/layouts
            return StatusCode(501);
        }

        /// <summary>
        /// check a layout against the feng shui rules without saving it
        /// </summary>
        /// <param name="layout">the room, the request if there is one, and every piece</param>
        /// <returns>broken rules, kept rules and a harmony score</returns>
        /// <response code="200">checked, harmony is 100 when every rule is followed</response>
        /// <response code="400">two pieces overlap, a piece is outside the room, a furniture code doesn't exist, or there's more of a piece than the client owns</response>
        /// <response code="401">no api key sent</response>
        /// <response code="404">the room or request doesn't exist</response>
        [HttpPost("check")]
        public ActionResult<CheckResultDTO> CheckLayout(LayoutCheckDTO layout)
        {
            //-----only the design for now, filled in on feature/rules-engine
            return StatusCode(501);
        }

        /// <summary>
        /// find how qi flows through a layout, from the door to the window
        /// </summary>
        /// <param name="layout">the room and every piece</param>
        /// <returns>the path qi takes and any squares it never reaches</returns>
        /// <response code="200">worked out, an empty room has no stuck squares</response>
        /// <response code="400">two pieces overlap, a piece is outside the room, a furniture code doesn't exist, or there's more of a piece than the client owns</response>
        /// <response code="401">no api key sent</response>
        /// <response code="404">the room doesn't exist</response>
        [HttpPost("qiflow")]
        public ActionResult<QiFlowDTO> GetQiFlow(LayoutCheckDTO layout)
        {
            //----only the design for now, filled in on feature/qi-flow
            return StatusCode(501);
        }

        /// <summary>
        /// get the consultation report for one of your saved layouts
        /// </summary>
        /// <param name="id">layout id</param>
        /// <returns>the client and request, what got fixed, what's still broken and the harmony</returns>
        /// <response code="200">the report, works without a request for your own room too</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">it's someone else's layout</response>
        /// <response code="404">no layout with that id</response>
        [HttpGet("{id}/report")]
        public ActionResult<ReportDTO> GetReport(int id)
        {
            //-------only the design for now, filled in on feature/reports
            return StatusCode(501);
        }
    }
}
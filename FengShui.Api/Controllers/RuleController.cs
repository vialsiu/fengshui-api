//--------the wording of the feng shui rules, the checks themselves live in code
using Microsoft.AspNetCore.Mvc;
using FengShui.Api.DTOs;

namespace FengShui.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuleController : ControllerBase
    {
        /// <summary>
        /// see every feng shui rule, or only the ones for one kind of room
        /// </summary>
        /// <param name="roomKind">bedroom, living or study, leave empty for all</param>
        /// <returns>the rules</returns>
        /// <response code="200">the list</response>
        /// <response code="401">no api key sent</response>
        [HttpGet]
        public ActionResult<IEnumerable<RuleDTO>> GetRules(string? roomKind)
        {
            //---only the design for now, filled in on feature/rules
            return StatusCode(501);
        }

        /// <summary>
        /// see one rule
        /// </summary>
        /// <param name="id">rule id</param>
        /// <returns>the rule</returns>
        /// <response code="200">found it</response>
        /// <response code="401">no api key sent</response>
        /// <response code="404">no rule with that id</response>
        [HttpGet("{id}")]
        public ActionResult<RuleDTO> GetRule(int id)
        {
            //------only the design for now, filled in on feature/rules
            return StatusCode(501);
        }

        /// <summary>
        /// add a rule's wording (admin only)
        /// </summary>
        /// <param name="rule">the new rule</param>
        /// <returns>the rule that was made</returns>
        /// <response code="201">made</response>
        /// <response code="400">missing code or title, or no check exists in code for that code</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        [HttpPost]
        public ActionResult<RuleDTO> PostRule(RuleCreateDTO rule)
        {
            //----only the design for now, filled in on feature/rules
            return StatusCode(501);
        }

        /// <summary>
        /// change a rule's wording (admin only)
        /// </summary>
        /// <param name="id">rule id</param>
        /// <param name="rule">the new wording</param>
        /// <response code="204">changed</response>
        /// <response code="400">missing code or title</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        /// <response code="404">no rule with that id</response>
        [HttpPut("{id}")]
        public IActionResult PutRule(int id, RuleCreateDTO rule)
        {
            //---------only the design for now, filled in on feature/rules
            return StatusCode(501);
        }

        /// <summary>
        /// remove a rule (admin only)
        /// </summary>
        /// <param name="id">rule id</param>
        /// <response code="204">removed</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        /// <response code="404">no rule with that id</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteRule(int id)
        {
            //---only the design for now, filled in on feature/rules
            return StatusCode(501);
        }
    }
}
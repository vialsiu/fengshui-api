//--------the wording of the feng shui rules, the checks themselves live in code
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FengShui.Api.Auth;
using FengShui.Api.DTOs;
using FengShui.Api.Mapping;
using FengShui.Api.Models;
using FengShui.Api.Repositories;
using FengShui.Api.Validation;

namespace FengShui.Api.Controllers
{
    /// <summary>
    /// the wording of the feng shui rules
    /// </summary>
    /// <param name="rules">where rules are stored</param>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RuleController(IRuleRepository rules) : ControllerBase
    {
        /// <summary>
        /// see every feng shui rule, or only the ones for one kind of room
        /// </summary>
        /// <param name="roomKind">bedroom, living or study, leave empty for all</param>
        /// <returns>the rules</returns>
        /// <response code="200">the list</response>
        /// <response code="400">that room kind doesn't exist</response>
        /// <response code="401">no api key sent</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RuleDTO>>> GetRules(string? roomKind)
        {
            List<Rule> found;
            if (string.IsNullOrWhiteSpace(roomKind))
            {
                found = await rules.GetAllAsync();
            }
            else
            {
                if (!EnumText.TryParse<RoomKind>(roomKind, out var kind))
                    return BadRequest($"the room kind has to be one of: {EnumText.Options<RoomKind>()}");

                //---this also brings back the rules for every room, they count in a bedroom too
                found = await rules.GetForRoomKindAsync(kind);
            }

            return found.OrderBy(r => r.Id).Select(r => r.ToDto()).ToList();
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
        public async Task<ActionResult<RuleDTO>> GetRule(int id)
        {
            var found = await rules.GetByIdAsync(id);
            if (found == null)
                return NotFound();

            return found.ToDto();
        }

        /// <summary>
        /// add a rule's wording (admin only)
        /// </summary>
        /// <param name="rule">the new rule</param>
        /// <returns>the rule that was made</returns>
        /// <response code="201">made</response>
        /// <response code="400">missing title, unknown category, severity or room kind, no check in code for that code, or the code already has wording</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        [HttpPost]
        [Authorize(Roles = ApiKeyDefaults.AdminRole)]
        public async Task<ActionResult<RuleDTO>> PostRule(RuleCreateDTO rule)
        {
            var error = RuleValidator.Validate(rule);
            if (error != null)
                return BadRequest(error);

            //------one wording per check, change the existing one with PUT instead
            if (await rules.GetByCodeAsync(rule.Code!.Trim()) != null)
                return BadRequest($"the rule {rule.Code.Trim()} already has wording, change it with PUT instead");

            var made = new Rule();
            rule.CopyTo(made);
            await rules.AddAsync(made);

            return CreatedAtAction(nameof(GetRule), new { id = made.Id }, made.ToDto());
        }

        /// <summary>
        /// change a rule's wording (admin only)
        /// </summary>
        /// <param name="id">rule id</param>
        /// <param name="rule">the new wording</param>
        /// <response code="204">changed</response>
        /// <response code="400">missing title, unknown category, severity or room kind, or the code belongs to another rule</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        /// <response code="404">no rule with that id</response>
        [HttpPut("{id}")]
        [Authorize(Roles = ApiKeyDefaults.AdminRole)]
        public async Task<IActionResult> PutRule(int id, RuleCreateDTO rule)
        {
            var error = RuleValidator.Validate(rule);
            if (error != null)
                return BadRequest(error);

            var existing = await rules.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            var sameCode = await rules.GetByCodeAsync(rule.Code!.Trim());
            if (sameCode != null && sameCode.Id != id)
                return BadRequest($"the code {rule.Code.Trim()} belongs to another rule");

            rule.CopyTo(existing);
            await rules.UpdateAsync(existing);

            return NoContent();
        }

        /// <summary>
        /// remove a rule (admin only)
        /// </summary>
        /// <param name="id">rule id</param>
        /// <response code="204">removed, the check stops counting until it gets wording again</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        /// <response code="404">no rule with that id</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = ApiKeyDefaults.AdminRole)]
        public async Task<IActionResult> DeleteRule(int id)
        {
            var existing = await rules.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await rules.DeleteAsync(existing);
            return NoContent();
        }
    }
}
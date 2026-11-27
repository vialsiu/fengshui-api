//---the kinds of furniture, everyone can read them, only the admin changes them
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
    /// the kinds of furniture you can place
    /// </summary>
    /// <param name="furniture">where furniture types are stored</param>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FurnitureTypeController(IFurnitureTypeRepository furniture) : ControllerBase
    {
        /// <summary>
        /// see every kind of furniture
        /// </summary>
        /// <returns>all furniture types, sorted by name</returns>
        /// <response code="200">the list</response>
        /// <response code="401">no api key sent</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FurnitureTypeDTO>>> GetFurnitureTypes()
        {
            var all = await furniture.GetAllAsync();
            return all.Select(f => f.ToDto()).ToList();
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
        public async Task<ActionResult<FurnitureTypeDTO>> GetFurnitureType(int id)
        {
            var found = await furniture.GetByIdAsync(id);
            if (found == null)
                return NotFound();

            return found.ToDto();
        }

        /// <summary>
        /// add a kind of furniture (admin only)
        /// </summary>
        /// <param name="furnitureType">the new furniture type</param>
        /// <returns>the furniture type that was made</returns>
        /// <response code="201">made</response>
        /// <response code="400">missing code or name, size out of range, unknown element, or the code is taken</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        [HttpPost]
        [Authorize(Roles = ApiKeyDefaults.AdminRole)]
        public async Task<ActionResult<FurnitureTypeDTO>> PostFurnitureType(FurnitureTypeCreateDTO furnitureType)
        {
            var error = FurnitureTypeValidator.Validate(furnitureType);
            if (error != null)
                return BadRequest(error);

            //------codes have a unique index, checking first gives a nicer message than a database error
            if (await furniture.GetByCodeAsync(furnitureType.Code!.Trim()) != null)
                return BadRequest($"the code {furnitureType.Code.Trim()} is already taken");

            var made = new FurnitureType();
            furnitureType.CopyTo(made);
            await furniture.AddAsync(made);

            return CreatedAtAction(nameof(GetFurnitureType), new { id = made.Id }, made.ToDto());
        }

        /// <summary>
        /// change a kind of furniture (admin only)
        /// </summary>
        /// <param name="id">furniture type id</param>
        /// <param name="furnitureType">the new details</param>
        /// <response code="204">changed</response>
        /// <response code="400">missing code or name, size out of range, unknown element, or the code is taken</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        /// <response code="404">no furniture type with that id</response>
        [HttpPut("{id}")]
        [Authorize(Roles = ApiKeyDefaults.AdminRole)]
        public async Task<IActionResult> PutFurnitureType(int id, FurnitureTypeCreateDTO furnitureType)
        {
            var error = FurnitureTypeValidator.Validate(furnitureType);
            if (error != null)
                return BadRequest(error);

            var existing = await furniture.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            //----the code can stay the same, it just can't be changed to another type's code
            var sameCode = await furniture.GetByCodeAsync(furnitureType.Code!.Trim());
            if (sameCode != null && sameCode.Id != id)
                return BadRequest($"the code {furnitureType.Code.Trim()} is already taken");

            furnitureType.CopyTo(existing);
            await furniture.UpdateAsync(existing);

            return NoContent();
        }

        /// <summary>
        /// remove a kind of furniture (admin only)
        /// </summary>
        /// <param name="id">furniture type id</param>
        /// <response code="204">removed</response>
        /// <response code="400">it's still used in a layout or a client's inventory</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        /// <response code="404">no furniture type with that id</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = ApiKeyDefaults.AdminRole)]
        public async Task<IActionResult> DeleteFurnitureType(int id)
        {
            var existing = await furniture.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            if (await furniture.IsInUseAsync(id))
                return BadRequest("it's still used in a layout or a client's inventory, take it out of those first");

            await furniture.DeleteAsync(existing);
            return NoContent();
        }
    }
}
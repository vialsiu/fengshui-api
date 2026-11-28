//------the list of jobs, each client asking for a room to be fixed
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
    /// requests from clients to fix a room, with what they own and their starting layout
    /// </summary>
    /// <param name="requests">where requests are stored</param>
    /// <param name="clients">used to check the client exists</param>
    /// <param name="rooms">used to check the room exists</param>
    /// <param name="furniture">used to turn furniture codes into types</param>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequestController(
        IRequestRepository requests,
        IClientRepository clients,
        IRoomRepository rooms,
        IFurnitureTypeRepository furniture) : ControllerBase
    {
        /// <summary>
        /// see every request, the first screen of the game
        /// </summary>
        /// <returns>all the requests with who's asking and which room</returns>
        /// <response code="200">the list, can be empty</response>
        /// <response code="401">no api key sent</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestDTO>>> GetRequests()
        {
            var all = await requests.GetAllWithDetailsAsync();
            return all.Select(r => r.ToDto()).ToList();
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
        public async Task<ActionResult<RequestDTO>> GetRequest(int id)
        {
            var found = await requests.GetWithDetailsAsync(id);
            if (found == null)
                return NotFound();

            return found.ToDto();
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
        public async Task<ActionResult<LayoutDTO>> GetStartLayout(int id)
        {
            var start = await requests.GetStartLayoutAsync(id);
            if (start == null)
                return NotFound();

            return start.ToDto();
        }

        /// <summary>
        /// add a request (admin only), it starts with an empty room
        /// </summary>
        /// <param name="request">who's asking, which room, their note and what they own</param>
        /// <returns>the request that was made</returns>
        /// <response code="201">made, with an empty starting layout</response>
        /// <response code="400">bad concern or quote, the client or room doesn't exist, the room is a player's own, an owned count is out of range, or a furniture code doesn't exist</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        [HttpPost]
        [Authorize(Roles = ApiKeyDefaults.AdminRole)]
        public async Task<ActionResult<RequestDTO>> PostRequest(RequestCreateDTO request)
        {
            var error = RequestValidator.Validate(request);
            if (error != null)
                return BadRequest(error);

            var (room, linkError) = await CheckClientAndRoomAsync(request);
            if (linkError != null)
                return BadRequest(linkError);

            var (inventory, inventoryError) = await BuildInventoryAsync(request.Inventory);
            if (inventoryError != null)
                return BadRequest(inventoryError);

            var made = new Request { Inventory = inventory! };
            request.CopyTo(made);

            //-------every request needs a starting layout so the room screen has something to load
            made.Layouts = new List<Layout>
            {
                new Layout
                {
                    Kind = LayoutKind.Start,
                    Name = $"{room!.Name} as it is",
                    RoomId = room.Id,
                    UpdatedAt = DateTime.UtcNow
                }
            };
            await requests.AddAsync(made);

            //---load it again with the client and room so the names come back too
            var saved = await requests.GetWithDetailsAsync(made.Id);
            return CreatedAtAction(nameof(GetRequest), new { id = made.Id }, saved!.ToDto());
        }

        /// <summary>
        /// change a request (admin only)
        /// </summary>
        /// <param name="id">request id</param>
        /// <param name="request">the new details</param>
        /// <response code="204">changed</response>
        /// <response code="400">bad concern or quote, the client or room doesn't exist, the room changed, a furniture code doesn't exist, or the client would own fewer than are already in the room</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        /// <response code="404">no request with that id</response>
        [HttpPut("{id}")]
        [Authorize(Roles = ApiKeyDefaults.AdminRole)]
        public async Task<IActionResult> PutRequest(int id, RequestCreateDTO request)
        {
            var error = RequestValidator.Validate(request);
            if (error != null)
                return BadRequest(error);

            //----plain load, no includes, the inventory gets replaced so it shouldn't be tracked
            var existing = await requests.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            //------the starting layout was drawn for this room, it can't just move to another one
            if (existing.RoomId != request.RoomId)
                return BadRequest("a request can't move to another room, make a new request instead");

            var (_, linkError) = await CheckClientAndRoomAsync(request);
            if (linkError != null)
                return BadRequest(linkError);

            var (inventory, inventoryError) = await BuildInventoryAsync(request.Inventory);
            if (inventoryError != null)
                return BadRequest(inventoryError);

            //--you can't own 1 nightstand if 2 are already standing in the room
            var start = await requests.GetStartLayoutAsync(id);
            if (start?.Placements != null)
            {
                foreach (var placed in start.Placements.GroupBy(p => p.FurnitureTypeId))
                {
                    var owned = inventory!.Where(i => i.FurnitureTypeId == placed.Key).Sum(i => i.Owned);
                    if (placed.Count() > owned)
                    {
                        var name = placed.First().FurnitureType.Code;
                        return BadRequest($"{placed.Count()} {name} are already in the room, the client has to own at least that many");
                    }
                }
            }

            request.CopyTo(existing);
            await requests.UpdateWithInventoryAsync(existing, inventory!);

            return NoContent();
        }

        /// <summary>
        /// remove a request (admin only)
        /// </summary>
        /// <param name="id">request id</param>
        /// <response code="204">removed, with its inventory and layouts</response>
        /// <response code="401">no api key sent</response>
        /// <response code="403">not the admin key</response>
        /// <response code="404">no request with that id</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = ApiKeyDefaults.AdminRole)]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var existing = await requests.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await requests.DeleteWithLayoutsAsync(existing);
            return NoContent();
        }

        //---checks the client exists and the room is one of the game's, returns the room for its name
        //------returning a tuple gives back two things at once without making a class for it
        //----ref https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
        private async Task<(Room? Room, string? Error)> CheckClientAndRoomAsync(RequestCreateDTO request)
        {
            if (!await clients.ExistsAsync(request.ClientId))
                return (null, $"there's no client with the id {request.ClientId}");

            var room = await rooms.GetByIdAsync(request.RoomId);
            if (room == null)
                return (null, $"there's no room with the id {request.RoomId}");

            //--------clients only send in the game's rooms, a player's own room is private to them
            if (room.PlayerId != null)
                return (null, "that room belongs to a player, pick one of the game's rooms");

            return (room, null);
        }

        //-----turns the codes in the inventory into furniture type ids, all in one database trip
        private async Task<(List<InventoryItem>? Items, string? Error)> BuildInventoryAsync(List<InventoryItemDTO> lines)
        {
            var codes = lines.Select(l => l.Furniture!.Trim()).ToList();
            var types = await furniture.GetByCodesAsync(codes);

            var missing = codes.Where(c => !types.ContainsKey(c)).ToList();
            if (missing.Count > 0)
                return (null, $"there's no furniture with the code: {string.Join(", ", missing)}");

            var items = lines
                .Select(l => new InventoryItem { FurnitureTypeId = types[l.Furniture!.Trim()].Id, Owned = l.Owned })
                .ToList();
            return (items, null);
        }
    }
}
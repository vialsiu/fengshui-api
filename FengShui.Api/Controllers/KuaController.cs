//--------works out someone's kua number and lucky directions from their birth year
using Microsoft.AspNetCore.Mvc;
using FengShui.Api.DTOs;

namespace FengShui.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KuaController : ControllerBase
    {
        /// <summary>
        /// work out a kua number, its group, element and the good and bad directions
        /// </summary>
        /// <param name="birthYear">year of birth, 1900 to 2099</param>
        /// <param name="formula">female or male, the two versions of the kua formula</param>
        /// <param name="bornBeforeFeb4">true if born before 4 february, the feng shui year starts then</param>
        /// <returns>the kua number, directions and the steps it took</returns>
        /// <response code="200">worked out, 1999 with the female formula gives 8</response>
        /// <response code="400">year outside 1900 to 2099, or the formula isn't female or male</response>
        /// <response code="401">no api key sent</response>
        [HttpGet]
        public ActionResult<KuaResultDTO> GetKua(int birthYear, string? formula, bool bornBeforeFeb4)
        {
            //---only the design for now, filled in on feature/kua
            return StatusCode(501);
        }
    }
}
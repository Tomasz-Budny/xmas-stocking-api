using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using xmas_stocking.Api.Models.Dto;

namespace xmas_stocking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrawController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation("for every attende draw one to give a gift")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(IEnumerable<AttendeeDto> attendees)
        {
            return Ok();
        }
    }
}

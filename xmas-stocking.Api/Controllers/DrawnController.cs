using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using xmas_stocking.Api.Models.Dto;
using xmas_stocking.Api.Services;

namespace xmas_stocking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrawnController : ControllerBase
    {
        protected readonly IDrawnService _drawnService;

        public DrawnController(IDrawnService drawnService)
        {
            _drawnService = drawnService;
        }

        [HttpPost]
        [SwaggerOperation("for every attende draw one to give a gift")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(IEnumerable<AttendeeDto> attendees)
        {
            _drawnService.DrawnAttendeesToGiveGift(attendees);
            return Ok();
        }
    }
}

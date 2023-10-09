using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using xmas_stocking.Api.Models;
using xmas_stocking.Api.Services;

namespace xmas_stocking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrawnController : ControllerBase
    {
        protected readonly IDrawnService _drawnService;
        protected readonly ISmtpService _smtpService;

        public DrawnController(IDrawnService drawnService, ISmtpService smtpService)
        {
            _drawnService = drawnService;
            _smtpService = smtpService;
        }

        [HttpPost]
        [SwaggerOperation("for every attende draw one to give a gift")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(IEnumerable<Attendee> attendees)
        {
            var giftPresenters =_drawnService.DrawnGiftPresenters(attendees);
            await _smtpService.SendEmailsToGiftPresenters(giftPresenters);
            return Ok();
        }
    }
}

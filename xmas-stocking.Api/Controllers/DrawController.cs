using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using xmas_stocking.Api.Models;
using xmas_stocking.Api.Services;

namespace xmas_stocking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrawController : ControllerBase
    {
        protected readonly IDrawService _drawService;
        protected readonly ISmtpService _smtpService;

        public DrawController(IDrawService drawnService, ISmtpService smtpService)
        {
            _drawService = drawnService;
            _smtpService = smtpService;
        }

        [HttpPost]
        [SwaggerOperation("for every attende draw one to give a gift")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(IEnumerable<Attendee> attendees)
        {
            var giftPresenters =_drawService.DrawGiftPresenters(attendees);
            await _smtpService.SendEmailsToGiftPresenters(giftPresenters);
            return Ok();
        }
    }
}

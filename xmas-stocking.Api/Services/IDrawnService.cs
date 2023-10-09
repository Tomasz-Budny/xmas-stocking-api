using xmas_stocking.Api.Models;
using xmas_stocking.Api.Models.Dto;

namespace xmas_stocking.Api.Services
{
    public interface IDrawnService
    {
        IEnumerable<AttendeeWithSelectedAtendee> DrawnAttendeesToGiveGift(IEnumerable<Attendee> attendes);
    }
}

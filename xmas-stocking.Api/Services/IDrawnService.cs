using xmas_stocking.Api.Models.Dto;

namespace xmas_stocking.Api.Services
{
    public interface IDrawnService
    {
        void DrawnAttendeesToGiveGift(IEnumerable<AttendeeDto> attendes);
    }
}

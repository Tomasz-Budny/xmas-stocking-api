using xmas_stocking.Api.Models.Dto;

namespace xmas_stocking.Api.Services
{
    public interface IDrawService
    {
        void DrawAttendeeToGiveGift(IEnumerable<AttendeeDto> attendes);
    }
}

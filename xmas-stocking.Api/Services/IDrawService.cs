using xmas_stocking.Api.Models.Dto;

namespace xmas_stocking.Api.Services
{
    public interface IDrawService
    {
        void DrawAttendeesToGiveGift(IEnumerable<AttendeeDto> attendes);
    }
}

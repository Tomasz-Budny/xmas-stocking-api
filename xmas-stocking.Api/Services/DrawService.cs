using xmas_stocking.Api.Models.Dto;

namespace xmas_stocking.Api.Services
{
    public class DrawService : IDrawService
    {
        public void DrawAttendeeToGiveGift(IEnumerable<AttendeeDto> attendes)
        {
            foreach (var attendee in attendes)
            {
                if(attendee.Name.Length < 2)
                {

                }
            }
        }
    }
}

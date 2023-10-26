using xmas_stocking.Api.Models;
using xmas_stocking.Api.Models.Dtos;

namespace xmas_stocking.Api.Mappers
{
    public static class AttendeeMapper
    {
        public static Attendee Map(AttendeeDto attendee)
        {
            return new Attendee()
            {
                Name = attendee.Name,
                Email = attendee.Email,
                PreferredGifts = attendee.PreferedGifts,
            };
        }
    }
}

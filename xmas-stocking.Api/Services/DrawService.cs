using EmailValidation;
using xmas_stocking.Api.Exceptions;
using xmas_stocking.Api.Models.Dto;

namespace xmas_stocking.Api.Services
{
    public class DrawService : IDrawService
    {
        private readonly int attendeeMinNameLength = 2;
        public void DrawAttendeesToGiveGift(IEnumerable<AttendeeDto> attendes)
        {
            foreach (var attendee in attendes)
            {
                if(attendee.Name.Length < attendeeMinNameLength)
                {
                    throw new AttendeNameIsTooShortException(attendeeMinNameLength);
                }

                if (EmailValidator.Validate(attendee.Email))
                {
                    throw new AttendeeEmailInvalidException();
                }
            }
        }
    }
}

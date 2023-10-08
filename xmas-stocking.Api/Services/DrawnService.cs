using EmailValidation;
using xmas_stocking.Api.Exceptions;
using xmas_stocking.Api.Models;
using xmas_stocking.Api.Models.Dto;

namespace xmas_stocking.Api.Services
{
    public class DrawnService : IDrawnService
    {
        private readonly int attendeeMinNameLength = 2;
        public void DrawnAttendeesToGiveGift(IEnumerable<AttendeeDto> attendes)
        {
            var attendeesLeftToSelect = attendes;
            var attendesWithRandomlySelectedAttendeeName = new List<Attendee>();

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

                var attendeesLeftToSelectWithoutCurrentAttendee = attendeesLeftToSelect.Where(att => att != attendee).ToList();

                var ListMaxIndex = attendeesLeftToSelectWithoutCurrentAttendee.Count - 1;
                var random = new Random();

                var drawedAttendee = attendeesLeftToSelectWithoutCurrentAttendee[random.Next(0, ListMaxIndex)];
                attendeesLeftToSelect = attendeesLeftToSelect.Where(att => att != drawedAttendee);

                var attendeeWithRandomlySelectedAttendee = new Attendee(attendee.Name, attendee.Email, drawedAttendee.Name);
                attendesWithRandomlySelectedAttendeeName.Add(attendeeWithRandomlySelectedAttendee);
            }

            PrintAttendeesWithRandomlySelectedAtendee(attendesWithRandomlySelectedAttendeeName);
        }
        private static void PrintAttendeesWithRandomlySelectedAtendee(IEnumerable<Attendee> attendees)
        {
            foreach (var attendee in attendees)
            {
                Console.WriteLine($"attendee name: {attendee.Name}, attendee email: {attendee.Email}, selected attendee name: {attendee.RandomlySelectedAttendeeName}\n");
            }
        }
    }
}

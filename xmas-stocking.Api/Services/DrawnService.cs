using EmailValidation;
using xmas_stocking.Api.Exceptions;
using xmas_stocking.Api.Models;

namespace xmas_stocking.Api.Services
{
    public class DrawnService : IDrawnService
    {
        private readonly int attendeeMinNameLength = 2;
        public IEnumerable<AttendeeWithSelectedAtendee> DrawnAttendeesToGiveGift(IEnumerable<Attendee> attendes)
        {
            if(attendes.Count() % 2 == 1)
            {
                throw new AttendeeListLengthIsOddException();
            }

            var attendeesLeftToSelect = attendes;
            var attendesWithRandomlySelectedAttendee = new List<AttendeeWithSelectedAtendee>();

            foreach (var attendee in attendes)
            {
                if(attendee.Name.Length < attendeeMinNameLength)
                {
                    throw new AttendeNameIsTooShortException(attendeeMinNameLength);
                }

                if (!EmailValidator.Validate(attendee.Email))
                {
                    throw new AttendeeEmailInvalidException();
                }

                var attendeesLeftToSelectWithoutCurrentAttendee = attendeesLeftToSelect.Where(att => att != attendee).ToList();

                if(attendeesLeftToSelectWithoutCurrentAttendee.Count == 0)
                {
                    var lastAttendeeWithRandomlySelectedAttendee = attendesWithRandomlySelectedAttendee[^1];
                    var attendeeWithSelectedAttendeeName = new AttendeeWithSelectedAtendee()
                    {
                        Name = attendee.Name,
                        Email = attendee.Email,
                        PrefferedGifts = attendee.PrefferedGifts,
                        RandomlySelectedAttendee = lastAttendeeWithRandomlySelectedAttendee
                    };
                    attendesWithRandomlySelectedAttendee.Add(attendeeWithSelectedAttendeeName);
                    continue;
                }

                var ListLength = attendeesLeftToSelectWithoutCurrentAttendee.Count;
                var random = new Random();

                var randomlySelectedAttendee = attendeesLeftToSelectWithoutCurrentAttendee[random.Next(0, ListLength)];
                attendeesLeftToSelect = attendeesLeftToSelect.Where(att => att != randomlySelectedAttendee);

                var attendeeWithRandomlySelectedAttendee = new AttendeeWithSelectedAtendee()
                {
                    Name = attendee.Name,
                    Email = attendee.Email,
                    PrefferedGifts = attendee.PrefferedGifts,
                    RandomlySelectedAttendee = randomlySelectedAttendee
                };

                attendesWithRandomlySelectedAttendee.Add(attendeeWithRandomlySelectedAttendee);
            }

            PrintAttendeesWithRandomlySelectedAtendee(attendesWithRandomlySelectedAttendee);
            return attendesWithRandomlySelectedAttendee;
        }
        private static void PrintAttendeesWithRandomlySelectedAtendee(IEnumerable<AttendeeWithSelectedAtendee> attendees)
        {
            Console.WriteLine("\n");
            foreach (var attendee in attendees)
            {
                Console.WriteLine($"attendee name: {attendee.Name}, attendee email: {attendee.Email}, selected attendee name: {attendee.RandomlySelectedAttendee.Name}\n");
            }
        }
    }
}

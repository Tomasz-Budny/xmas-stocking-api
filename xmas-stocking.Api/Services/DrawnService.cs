using EmailValidation;
using xmas_stocking.Api.Exceptions;
using xmas_stocking.Api.Mappers;
using xmas_stocking.Api.Models;

namespace xmas_stocking.Api.Services
{
    public class DrawnService : IDrawnService
    {
        private readonly int attendeeMinNameLength = 2;
        public IEnumerable<GiftPresenter> DrawnGiftPresenters(IEnumerable<Attendee> attendes)
        {
            if(attendes.Count() % 2 == 1)
            {
                throw new AttendeeListLengthIsOddException();
            }

            var attendeesLeftToSelect = attendes;
            var giftPresenters = new List<GiftPresenter>();

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

                var giftPresentersWithoutCurrentAttendee = attendeesLeftToSelect.Where(att => att != attendee).ToList();

                if(giftPresentersWithoutCurrentAttendee.Count == 0)
                {
                    var lastGiftPresenter = giftPresenters[^1];

                   var currentGiftPresenter = GiftPresentersMapper.Map(attendee, lastGiftPresenter.GiftRecipient);
                    giftPresenters.Add(currentGiftPresenter);
                    lastGiftPresenter.GiftRecipient = attendee;
                    continue;
                }

                var ListLength = giftPresentersWithoutCurrentAttendee.Count;
                var random = new Random();

                var giftRecipient = giftPresentersWithoutCurrentAttendee[random.Next(0, ListLength)];
                attendeesLeftToSelect = attendeesLeftToSelect.Where(att => att != giftRecipient);

                var giftPresenter = GiftPresentersMapper.Map(attendee, giftRecipient);

                giftPresenters.Add(giftPresenter);
            }

            PrintGiftPresenters(giftPresenters);
            return giftPresenters;
        }
        private static void PrintGiftPresenters(IEnumerable<GiftPresenter> giftPresenters)
        {
            Console.WriteLine("\n");
            foreach (var giftPresenter in giftPresenters)
            {
                Console.WriteLine($"gift presenter name: {giftPresenter.Name}, gift presenter email: {giftPresenter.Email}, gift recipient name: {giftPresenter.GiftRecipient.Name}\n");
            }
        }
    }
}

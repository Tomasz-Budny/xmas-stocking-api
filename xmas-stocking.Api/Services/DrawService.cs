﻿using EmailValidation;
using xmas_stocking.Api.Dtos;
using xmas_stocking.Api.Exceptions;
using xmas_stocking.Api.Mappers;
using xmas_stocking.DAL.Persistance.Models;

namespace xmas_stocking.Api.Services
{
    public class DrawService : IDrawService
    {
        private readonly int attendeeMinNameLength = 2;
        public Draw DrawGiftPresenters(IEnumerable<AttendeeDto> attendeDtos)
        {
            if(attendeDtos.Count() % 2 == 1)
            {
                throw new AttendeeListLengthIsOddException();
            }

            var attendees = attendeDtos.Select(attendee => AttendeeMapper.Map(attendee));
            var attendeesLeftToSelect = attendees;
            var giftPresenters = new List<GiftPresenter>();

            foreach (var attendee in attendees)
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
            return new Draw()
            {
                Attendees = giftPresenters,
                NumberOfAttendees = giftPresenters.Count()
            };
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

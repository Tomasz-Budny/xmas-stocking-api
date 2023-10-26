using xmas_stocking.DAL.Persistance.Models;

namespace xmas_stocking.Api.Mappers
{
    public static class GiftPresentersMapper
    {
        public static GiftPresenter Map(Attendee attendee, Attendee giftRecipient)
        {
            return new GiftPresenter()
            {
                Name = attendee.Name,
                Email = attendee.Email,
                GiftRecipient = giftRecipient
            };
        }
    }
}

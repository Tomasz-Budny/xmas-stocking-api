using xmas_stocking.Api.Models;

namespace xmas_stocking.Api.Services
{
    public interface IDrawnService
    {
        IEnumerable<GiftPresenter> DrawnGiftPresenters(IEnumerable<Attendee> attendes);
    }
}

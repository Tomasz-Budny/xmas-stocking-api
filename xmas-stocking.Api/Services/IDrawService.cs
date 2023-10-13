using xmas_stocking.Api.Models;

namespace xmas_stocking.Api.Services
{
    public interface IDrawService
    {
        IEnumerable<GiftPresenter> DrawGiftPresenters(IEnumerable<Attendee> attendes);
    }
}

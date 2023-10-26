using xmas_stocking.Api.Models;
using xmas_stocking.Api.Models.Dtos;

namespace xmas_stocking.Api.Services
{
    public interface IDrawService
    {
        IEnumerable<GiftPresenter> DrawGiftPresenters(IEnumerable<AttendeeDto> attendes);
    }
}

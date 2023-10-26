using xmas_stocking.Api.Dtos;
using xmas_stocking.DAL.Persistance.Models;

namespace xmas_stocking.Api.Services
{
    public interface IDrawService
    {
        Draw DrawGiftPresenters(IEnumerable<AttendeeDto> attendes);
    }
}

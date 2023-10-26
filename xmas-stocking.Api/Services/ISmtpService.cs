using xmas_stocking.DAL.Persistance.Models;

namespace xmas_stocking.Api.Services
{
    public interface ISmtpService
    {
        Task SendEmailsToGiftPresenters(IEnumerable<GiftPresenter> giftPresenters);
    }
}

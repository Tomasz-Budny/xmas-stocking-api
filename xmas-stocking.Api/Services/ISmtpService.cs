using xmas_stocking.Api.Models;

namespace xmas_stocking.Api.Services
{
    public interface ISmtpService
    {
        Task SendEmailsToGiftPresenters(IEnumerable<GiftPresenter> giftPresenters);
    }
}

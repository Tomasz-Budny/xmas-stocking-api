using xmas_stocking.Api.Models;

namespace xmas_stocking.Api.Services
{
    public class SmtpService : ISmtpService
    {
        public Task SendEmailsToGiftPresenters(IEnumerable<GiftPresenter> giftPresenters)
        {
            throw new NotImplementedException();
        }
    }
}

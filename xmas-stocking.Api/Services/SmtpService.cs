using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using xmas_stocking.Api.Options;
using xmas_stocking.DAL.Persistance.Models;

namespace xmas_stocking.Api.Services
{
    public class SmtpService : ISmtpService
    {
        private readonly SmtpOptions _smtpOptions;

        public SmtpService(IOptions<SmtpOptions> smtpOptions)
        {
            _smtpOptions = smtpOptions.Value;
        }
        public async Task SendEmailsToGiftPresenters(IEnumerable<GiftPresenter> giftPresenters)
        {
            var tasks = new List<Task>();

            foreach (var giftPresenter in giftPresenters)
            {
                tasks.Add(SendEmailToGiftPresenter(giftPresenter));
            }

            await Task.WhenAll(tasks);
        }

        private async Task SendEmailToGiftPresenter(GiftPresenter giftPresenter)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_smtpOptions.From));
            email.To.Add(MailboxAddress.Parse(giftPresenter.Email));
            email.Subject = "Losowanie osoby na mikołajki";
            email.Body = new TextPart(TextFormat.Html) { Text = GetGiftPresenterEmailTemplate(giftPresenter) };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpOptions.Host, _smtpOptions.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpOptions.UserName, _smtpOptions.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        private static string GetGiftPresenterEmailTemplate(GiftPresenter giftPresenter)
        {
            var header = $"<h1>Cześć, {giftPresenter.Name}</h1><p>Wylosowana przez Ciebie osoba to: <b>{giftPresenter.GiftRecipient.Name}</b></p>";
            var additional = string.IsNullOrWhiteSpace(giftPresenter.GiftRecipient.PreferredGifts) ? string.Empty : $"<p>Preferowane przez to osobę prezenty to: {giftPresenter.GiftRecipient.PreferredGifts}</p>";
            var footer = "<p>Pozdrawiamy!</p>";

            return string.Concat(header, additional, footer);
        }
    }
}

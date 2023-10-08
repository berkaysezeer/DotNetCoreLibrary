using SendGrid.Helpers.Mail;
using SendGrid;

namespace HangFireApp.Web.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Sender(string userId, string message)
        {
            //bu user id'ye sahip kullanıcıyı bul ve eposta adresini kullan

            var apiKey = _configuration.GetSection("APIs")["SendGridApp"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("***", "Example User");
            var subject = "HangFire App'e Hoş Geldin";
            var to = new EmailAddress("***", "Example User");
            //var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = $"<strong>{message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}

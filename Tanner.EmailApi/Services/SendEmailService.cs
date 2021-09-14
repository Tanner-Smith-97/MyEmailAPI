namespace Tanner.EmailApi.Services
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class SendEmailService
    {
        private readonly string _apiKey;
        public SendEmailService(string apiKey)
        {
            _apiKey = apiKey;
        }
        
        public async Task SendEmail(string sendTo, string content)
        {
            var apiKey = _apiKey;
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("ts@tannersmith.dev", "Tanner Smith");

            var to = new EmailAddress("smithjtanner@gmail.com", "Tanner");
            
            var msg = MailHelper.CreateSingleEmail(from, to, "test", content, "<p>" + content + "</p>");
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
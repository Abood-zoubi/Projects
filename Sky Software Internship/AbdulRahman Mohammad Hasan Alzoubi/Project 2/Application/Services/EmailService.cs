using System.Net.Mail;
using Biding_management_System.Application.Interfaces;

namespace Biding_management_System.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var message = new MailMessage("no-reply@SkySoftware.com", to, subject, body);
            await _smtpClient.SendMailAsync(message);
        }
    }
}

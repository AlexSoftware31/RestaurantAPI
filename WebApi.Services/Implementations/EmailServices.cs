using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class EmailServices(IConfiguration configuration) : IEmailServices
    {
        private readonly IConfiguration _configuration = configuration;

        public async Task SendEmailAsync(string subject, string email, string body)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(
            _configuration["SmtpSettings:SenderName"],
            _configuration["SmtpSettings:SenderEmail"]));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("html")
            {
                Text = body
            };

            using var client = new SmtpClient();
            await client.ConnectAsync(_configuration["SmtpSettings:Server"],
                int.Parse(_configuration["SmtpSettings:Port"]),
                SecureSocketOptions.StartTls);

            await client.AuthenticateAsync(
                _configuration["SmtpSettings:Username"],
                _configuration["SmtpSettings:Password"]);

            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);

        }

       
    }
}

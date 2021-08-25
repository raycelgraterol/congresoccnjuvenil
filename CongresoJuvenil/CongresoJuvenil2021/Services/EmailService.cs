using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;

namespace CongresoJuvenil2021.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Send(string to, string subject, string html, string from = "info@congresoccnjuvenil.com")
        {
            try
            {
                from = string.IsNullOrEmpty(_configuration["smtp:SmtpUser"]) ? from : _configuration["smtp:SmtpUser"];

                //create message
                var email = new MimeMessage();
                var address = MailboxAddress.Parse(from);
                address.Name = "Congreso Juvenil 2021";
                email.From.Add(address);
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                email.Headers.Add("X-Mailer-Machine", Environment.MachineName);
                email.Body = new TextPart(TextFormat.Html) { Text = html };

                // send email
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_configuration["smtp:SmtpHost"], int.Parse(_configuration["smtp:SmtpPort"]), SecureSocketOptions.SslOnConnect);
                await smtp.AuthenticateAsync(_configuration["smtp:SmtpUser"], _configuration["smtp:SmtpPass"]);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
            catch (System.Exception ex)
            {
            }
        }
    }
}

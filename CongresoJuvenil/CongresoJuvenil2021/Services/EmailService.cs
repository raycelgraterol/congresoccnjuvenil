using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Microsoft.Extensions.Configuration;

namespace CongresoJuvenil2021.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Send(string to, string subject, string html, string from = "")
        {
            try
            {
                //create message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(from));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = html };

                // send email
                using var smtp = new SmtpClient();
                smtp.Connect(_configuration["smtp:SmtpHost"], int.Parse(_configuration["smtp:SmtpPort"]), SecureSocketOptions.SslOnConnect);
                smtp.Authenticate(_configuration["smtp:SmtpUser"], _configuration["smtp:SmtpPass"]);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}

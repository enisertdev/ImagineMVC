using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Imagine.Business.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly string email;
        private readonly string password;
        public EmailService(IConfiguration configuration)
        {
            email = configuration["EmailSettings:Email"];
            password = configuration["EmailSettings:Password"];
        }


        public async Task SendEmailAsync(string email, string subject, string confirmUrl)
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(this.email, password);

                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(this.email);
                    mailMessage.Subject = subject;
                    mailMessage.Body = CreateHtmlMessage(email, confirmUrl);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(email);


                    try
                    {
                        await client.SendMailAsync(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while sending the email: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        

        public string CreateHtmlMessage(string email, string confirmUrl)
        {
            return $@"
                <html>
                <body>
                    <h2>Thank You for Registering!</h2>
                    <p>Dear {email},</p>
                    <p>Thank you for registering with us. Please confirm your email address by clicking the link below:</p>
                    <a href = ""{confirmUrl}"">Confirm your email</a>
                    <p>If you did not create an account, no further action is required.</p>
                    <p>Best regards,<br/>The Imagine Team</p>
                </body>
                </html>";
        }
    }
}

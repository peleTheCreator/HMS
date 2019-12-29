using HotelManagementSystem.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attachment = SendGrid.Helpers.Mail.Attachment;

namespace HotelManagementSystem.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        private  Task Execute(string sendGridKey, string subject, string message, string email )
        {

            var client = new SendGridClient(sendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("pelegocoded@gmail.com", Options.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            // Disable click tracking.
            msg.SetClickTracking(false, false);
            try
            {
                return client.SendEmailAsync(msg);
            }
            catch (Exception)
            {
                return client.SendEmailAsync(msg);
            }



        }
    }
}

//var stream = new MemoryStream();
//var writer = new StreamWriter(stream, Encoding.UTF8);
//await writer.WriteAsync(message);
//await writer.FlushAsync();
//stream.Position = 0;
//var reader = new StreamReader(stream, Encoding.UTF8);

//var banner2 = new Attachment()
//{
//    Content = Convert.ToBase64String(message),
//    Type = "application/pdf",
//    Filename = "banner2.png",
//    Disposition = "inline",
//    ContentId = "Banner 2"
//};
//msg.AddAttachment(banner2);
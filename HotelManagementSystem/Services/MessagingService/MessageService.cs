using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETCore.MailKit;
using MimeKit;
using System.IO;
using NETCore.MailKit.Core;
using HotelManagementSystem.Data;
using MailKit.Net.Smtp;
//using MailKit.Net.Smtp;

namespace HotelManagementSystem.Services.MessagingService
{
    public class MessageService : IMessageService
    {
        public async Task SendEmailAsync(string fromDisplayName,
            string fromEmailAddress,
            string toName,
            string toEmailAddress,
            string Subject,
            string message,
            params Attachment[] attachments)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(fromEmailAddress, fromEmailAddress));
            email.To.Add(new MailboxAddress(toName, toEmailAddress));
            email.Subject = Subject;

            var body = new BodyBuilder
            {
                HtmlBody = message
               
            };
            foreach (var attachment in attachments)
            {
                using (var stream = await attachment.ContentToStreamAsync())
                {
                    body.Attachments.Add(attachment.Filename, stream);
                }
            }
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback =
                    (sender, certificate, certChainType, errors) => true;
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.ConnectAsync("smtp.gmail.com", 587, false).ConfigureAwait(false);
                await client.AuthenticateAsync("pelegocoded@gmail.com", "Micr0s0ft_").ConfigureAwait(false);
                await client.SendAsync(email).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
    //public class MessageService : EmailService, IMessageService
    //{
    //    private readonly IMailKitProvider _mailKitProvider;

    //    public MessageService(IMailKitProvider provider) : base(provider)
    //    {
    //        _mailKitProvider = provider;
    //    }

    //    public async Task SendAsync(MimeMessage message)
    //    {
    //        message.From.Add(new MailboxAddress(_mailKitProvider.Options.SenderEmail));
    //        using (var emailClient = _mailKitProvider.SmtpClient)
    //        {
    //            if (!emailClient.IsConnected)
    //            {
    //                await emailClient.AuthenticateAsync(_mailKitProvider.Options.Account,
    //                _mailKitProvider.Options.Password);
    //                await emailClient.ConnectAsync(_mailKitProvider.Options.Server,
    //                _mailKitProvider.Options.Port, _mailKitProvider.Options.Security);
    //            }
    //            await emailClient.SendAsync(message);
    //            await emailClient.DisconnectAsync(true);
    //        }
    //    }

    //    public async Task SendAsync(EmailRequest emailRequest)
    //    {
    //        MimeMessage mimeMessage = new MimeMessage();
    //        mimeMessage.To.Add(new MailboxAddress(emailRequest.ToAddress));
    //        mimeMessage.Subject = emailRequest.Subject;
    //        var builder = new BodyBuilder { HtmlBody = emailRequest.Body };
    //        if (emailRequest.Attachment != null)
    //        {
    //            using (MemoryStream memoryStream = new MemoryStream())
    //            {
    //                await emailRequest.Attachment.CopyToAsync(memoryStream);
    //                builder.Attachments.Add(emailRequest.Attachment.FileName, memoryStream.ToArray());
    //            }

    //        }
    //        mimeMessage.Body = builder.ToMessageBody();
    //        await SendAsync(mimeMessage);
    //    }
    //}
}

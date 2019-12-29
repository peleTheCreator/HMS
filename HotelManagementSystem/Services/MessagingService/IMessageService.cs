using System;
using System.Threading.Tasks;
using HotelManagementSystem.Data;
using MimeKit;
using NETCore.MailKit.Core;

namespace HotelManagementSystem.Services.MessagingService
{
    public interface IMessageService
    {
        Task SendEmailAsync(
            string fromDisplayName,
            string fromEmailAddress,
            string toName,
            string toEmailAddress,
            string Subject,
            string message,
            params Attachment[] attachments);
    }
    //public interface IMessageService : IEmailService
    //{
    //    Task SendAsync(MimeMessage message);
    //    Task SendAsync(EmailRequest emailRequest);
    //}
}

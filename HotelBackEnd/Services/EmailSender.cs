﻿//using HotelManagementSystem.Data;
//using Microsoft.AspNetCore.Identity.UI.Services;
//using Microsoft.Extensions.Options;
//using SendGrid;
//using SendGrid.Helpers.Mail;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace HotelBackEnd.Services
//{
//    public class EmailSender : IEmailSender
//    {
//        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
//        {
//            Options = optionsAccessor.Value;
//        }

//        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

//        public Task SendEmailAsync(string email, string subject, string message)
//        {
//            return Execute(Options.SendGridKey, subject, message, email);
//        }

//        private Task Execute(string sendGridKey, string subject, string message, string email)
//        {
//            var client = new SendGridClient(sendGridKey);
//            var msg = new SendGridMessage()
//            {
//                From = new EmailAddress("pelegocoded@gmail.com", Options.SendGridUser),
//                Subject = subject,
//                PlainTextContent = message,
//                HtmlContent = message
//            };
//            msg.AddTo(new EmailAddress(email));
//            // Disable click tracking.
//            msg.SetClickTracking(false, false);

//            return client.SendEmailAsync(msg);
//        }
//    }
//}

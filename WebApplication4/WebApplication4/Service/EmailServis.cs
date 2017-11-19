﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WebApplication4.Service
{
    
    public class EmailServis
    {
        public SmtpClient _smtpClient { get; set; }
        public EmailServis()
        {
            _smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials =
               new NetworkCredential("gym550182@gmail.com", "!QAZ2wsx#EDC")
            };
        }
        public MailMessage CreateMailMessage(Models.ContactForm model)
        {
            var mailMessage = new MailMessage
            {
                Sender = new MailAddress("gym550182@gmail.com"),
                From = new MailAddress("gym550182@gmail.com"),
                To = { "gym550182@gmail.com" },
                Subject = model.Subject,
                Body = model.Body,
                IsBodyHtml = true
            };
            return mailMessage;
        }
        public void SendEmail(MailMessage message)
        {
            _smtpClient.Send(message);
        }
    }

}
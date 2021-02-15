using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailApp
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "login@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                //https://www.androidauthority.com/gmail-smtp-settings-801100/
                // Handle less security app problem
                // confirm registration link
                // https://localhost:44351/Account/ConfirmEmail?userId=d375250f-9e10-46d1-a6fa-f80751387687&code=CfDJ8Ne7l0jkhmtEhjB4M3zlkZ1bB0c%2BMe6BHbIaRGdPjFn%2BJ86jj45sdIfM4hQYT34jwHNMPpv6iUdFsMOeCnbUmLCp3baxt5XzEJEIn61lpzCCs2ToId%2BLiUja0wI8db8Vt%2Bpxc9QvD%2BcqyswJMMp2v9AQYw8lcMiTfykkUSWVcyDHkkTM7GbCiJo1F6eEukvoNv%2FzKvzZx7hFcOXuHwJVapHRcFv1IThzwiYxxwg2NSI9FfB%2BouQuBkR%2BTV9VOfk2sw%3D%3D
                // forgot password link
                // https://localhost:44351/Account/ResetPassword?userId=d375250f-9e10-46d1-a6fa-f80751387687&amp;code=CfDJ8Ne7l0jkhmtEhjB4M3zlkZ2ivLL6Y%2FhWonBJrn8tK3zyw0sRITiLQlv7JUQjG%2B09NFOjkLb81v9HJ%2BWAEHbg9kt%2FP%2Bg7385JctD0BsE653oFcX0YzD8HcEyHbKZ5b8UrMm6dXa3%2F1%2Fc%2B4w6J5oPHaeSMEV7zWSk1%2BQvSXlrjqZQiS2u6m2NPky%2FuYiDmbqBFTcnc04w8Y6fLHxEEK7yKq3FzZZ03fzBWEEL5cxENDyf8

                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("login@gmail.com", "password");                
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}

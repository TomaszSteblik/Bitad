﻿using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;

namespace BitadAPI.Services
{
    public interface IMailService
    {
        public Task SendActivationMail(string address, string activationCode, string receiver);
    }
    public class MailService : IMailService
    {
        private string _emailAddress;
        private string _emailPassword;
        private string _serverUrl;
        private string _smtpServer;
        
        public MailService()
        {
            _emailAddress = Environment.GetEnvironmentVariable("EMAIL_ADDRESS");
            _emailPassword = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
            _serverUrl = Environment.GetEnvironmentVariable("SERVER_URL");
            _smtpServer = Environment.GetEnvironmentVariable("SMTP_SERVER");
        }
        
        public async Task SendActivationMail(string address, string activationCode, string receiver)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Bitad2021", _emailAddress));
            message.To.Add(new MailboxAddress(receiver, address));
            message.Subject = "Aktywacja konta Bitad2021";
            var text = $"{_serverUrl}/account-activation/{activationCode}";
            message.Body = new TextPart("plain"){ Text = text };
            
            using (var client = new SmtpClient()) {
                await client.ConnectAsync (_smtpServer, 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync (_emailAddress, _emailPassword);

                await client.SendAsync(message);

                await client.DisconnectAsync (true);
            }

        }
    }
}
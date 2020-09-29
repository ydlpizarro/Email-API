using ApiEmail.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmail.Repositories
{
    public class EmailRepository
    {
        public void Send(Email email)
        {
            MimeMessage mimeMessage;

            try
            {
                mimeMessage = createMimeMessage(email);
                sendServer(mimeMessage);
            }
            catch (Exception exception)
            {
                throw exception;
            }             
        }

        #region private methods

        private MimeMessage createMimeMessage(Email email)
        {
            MimeMessage mimeMessage;

            try
            {
                mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(Commons.From));
                mimeMessage.To.Add(new MailboxAddress(email.To));
                mimeMessage.Subject = email.Subject;

                BodyBuilder bodyBuilder = new BodyBuilder { HtmlBody = string.Format(email.Body) };
                mimeMessage.Body = bodyBuilder.ToMessageBody();                
            }
            catch (Exception exception)
            {
                throw exception;                
            }

            return mimeMessage;
        }

        private void sendServer(MimeMessage mimeMessage)
        {
            SmtpClient smtpClient;
            
            try
            {
                smtpClient = new SmtpClient();
                smtpClient.ConnectAsync(Commons.SmtpServer, Commons.Port, true);
                smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
                smtpClient.Authenticate(Commons.UserName, Commons.Password);
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion
    }
}

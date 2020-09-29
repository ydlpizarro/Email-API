using ApiEmail.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmail.Repositories
{
    public class EmailBO
    {
        public EmailBO()
        {
            
        }

        public void Send(Email email)
        {
            EmailRepository emailRepository;

            try
            {
                emailRepository = new EmailRepository();
                emailRepository.Send(email);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

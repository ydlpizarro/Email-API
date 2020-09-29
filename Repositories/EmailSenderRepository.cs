using ApiEmail.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmail.Repositories
{
    public interface EmailSenderRepository
    {
        Task SendEmailAsync(MessageBO message);
    }
}

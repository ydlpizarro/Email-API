using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEmail.Business;
using ApiEmail.Models;
using ApiEmail.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiEmail.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly EmailSenderRepository _emailSenderRepository;


        public EmailController(EmailSenderRepository emailSenderRepository)
        {
            _emailSenderRepository = emailSenderRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Email email)
        {
            //var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
            var message = new MessageBO(new string[] { email.To }, email.Subject, email.Body, null);
            await _emailSenderRepository.SendEmailAsync(message);
            return Ok();
        }
    }
}

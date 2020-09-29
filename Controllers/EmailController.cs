using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ApiEmail.Models;
using ApiEmail.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiEmail.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public HttpResponseMessage Post(Email email)
        {
            HttpResponseMessage httpResponseMessage;
            EmailBO emailBO;           

            try
            {
                emailBO = new EmailBO();
                emailBO.Send(email);
                httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return httpResponseMessage;
        }
    }
}

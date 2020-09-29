using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmail
{
    public static class Commons
    {
        
        public static string From { get; set; }
        public static string SmtpServer { get; set; }
        public static int Port { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
    }    
}

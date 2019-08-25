using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantTimesheet.Models
{
    public class LoginModel
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string IMEI { get; set; }
        public string Channel { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantTimesheet.Models
{
    public class LoginResponse
    {
        public string status { get; set; }
        public int isExistLoginAuth { get; set; }
        public int record_count { get; set; }
        public Records records { get; set; }
    }

    public class Records
    {
        public __invalid_type__0 __invalid_name__0 { get; set; }
    }

    public class __invalid_type__0
    {
        public string UserID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserMobile { get; set; }
        public string UserEmail { get; set; }
        public string DeviceToken { get; set; }
    }
}

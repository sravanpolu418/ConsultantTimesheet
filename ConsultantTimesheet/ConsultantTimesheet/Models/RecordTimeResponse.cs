using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantTimesheet.Models
{
    class RecordTimeResponse
    {
    }
    public class RootobjectRecord
    {
        public string status { get; set; }
        public object isExistUserDailyCheckInandOut { get; set; }
        public string messagetext { get; set; }
        public string ClockInOutUniqueKey { get; set; }
    }

}

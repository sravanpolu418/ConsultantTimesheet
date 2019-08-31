using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantTimesheet.Models
{
    class RecordTimeModel
    {
        public string UserID { get; set; }
        public string ClientProjectID { get; set; }
        public string CheckIndate { get; set; }
        public string checkInTime { get; set; }
        public string checkInLat { get; set; }
        public string checkInLong { get; set; }
        public string isAutoCheckin { get; set; }      
        public string checkInReason { get; set; }
        public string CheckInComment { get; set; }
        public string projectLocationID { get; set; }
        public string DeviceToken { get; set; }
    }
}

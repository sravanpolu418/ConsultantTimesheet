using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantTimesheet.Models
{

}



public class Rootobject
{
    public string status { get; set; }
    public int isExistLoginAuth { get; set; }
    public int record_count { get; set; }
    public Record[] records { get; set; }
}

public class Record
{
    public string UserID { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string UserMobile { get; set; }
    public string UserEmail { get; set; }
    public string DeviceToken { get; set; }
}

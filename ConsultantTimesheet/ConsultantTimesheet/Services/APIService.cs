using ConsultantTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Newtonsoft.Json.Linq;

namespace ConsultantTimesheet.Services
{
    public class APIService
    {
        public void GetToken(String email, String passwod)
        {
            var httpClinet = new HttpClient();
        }

        public static class Globals
        {
           
            public static String UserID = "0"; // Modifiable
           
        }

        public class jsonResponseClass
        {
            public string status { get; set; }
            public string record_count { get; set; }
            public string UserID { get; set; }
            public string DeviceToken { get; set; }
        }


        public async Task<bool> LoginAsync(string userName, string password)
        {
            bool success = false;
            var keyValues = new LoginModel()
            {
                UserEmail = userName,
                UserPassword = password,
                IMEI= "1234567",
                Channel= "Mobile"

            };
            var json = JsonConvert.SerializeObject(keyValues);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            string myContent = await content.ReadAsStringAsync();

            var client = new HttpClient();
            var request = await client.PostAsync("http://techsamhitasolutions.com/employeecheckinapis/LogIn/", content);
            request.EnsureSuccessStatusCode();
            var response = await request.Content.ReadAsStringAsync();        
            Rootobject res = JsonConvert.DeserializeObject<Rootobject>(response);                  

            String status = res.status;
            Globals.UserID = res.records[0].UserID;


            if (status == "Success")
            {
                success= true;
            }

            return success;

        }

        public async Task<bool> RecordTimePost(string date, string time, string lattitude, string langitude)
        {
            bool success = false;
            var keyValues = new RecordTimeModel()
            {
                UserID = Globals.UserID,
                ClientProjectID = "1",
                CheckIndate = date,
                checkInTime = time,
                checkInLat = lattitude,                
                checkInLong = langitude,
                isAutoCheckin = "1",
                checkInReason = "Mobile",
                CheckInComment = "Mobile",
                projectLocationID = "1",
                DeviceToken = "Mobile"

            };

            var json = JsonConvert.SerializeObject(keyValues);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            string myContent = await content.ReadAsStringAsync();

            var client = new HttpClient();
            var request = await client.PostAsync("http://techsamhitasolutions.com/employeecheckinapis/ClockIn/", content);
            request.EnsureSuccessStatusCode();
            var response = await request.Content.ReadAsStringAsync();
            RootobjectRecord res = JsonConvert.DeserializeObject<RootobjectRecord>(response);
            String status = res.status;
            if (status == "Success")
            {
                success = true;
            }

            return success;
        }

    }
}

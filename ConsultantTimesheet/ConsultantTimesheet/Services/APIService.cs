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

        public class jsonResponseClass
        {
            public string isExistLoginAuth { get; set; }
            public string status { get; set; }
            public string record_count { get; set; }
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
            jsonResponseClass res = JsonConvert.DeserializeObject<jsonResponseClass>(response);

            String status = res.status;
            if(status == "Success")
            {
                success= true;
            }

            return success;





        }
    }
}

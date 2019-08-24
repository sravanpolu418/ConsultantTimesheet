using ConsultantTimesheet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ConsultantTimesheet.Services
{
    public class APIService
    {
        public void GetToken(String email, String passwod)
        {
            var httpClinet = new HttpClient();
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            var loginModel = new LoginModel()
            {
                Email = email,
                Password = password
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://techsamhitasolutions.com/employeecheckinapis/LogIn/", content);
            string output = await response.Content.ReadAsStringAsync();
           var jresp= JsonConvert.DeserializeObject<dynamic>(output);
            return response.IsSuccessStatusCode;
        }
    }
}

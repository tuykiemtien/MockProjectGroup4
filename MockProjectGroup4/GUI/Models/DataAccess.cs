using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using DTO;


namespace GUI.Models
{
    public class DataAccess
    {
        private string ApiUrl = @"http://localhost:52791/api/";
        private static DataAccess instance;

        public static DataAccess Instance
        {
            get { if (instance == null) instance = new DataAccess(); return DataAccess.instance; }
            private set => instance = value;
        }

        private DataAccess() { }

        public AccountDTO Login(string username, string password)
        {
            AccountDTO account = null;
            using( var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                var responseTask = client.GetAsync("customer?username=" + username + "&password=" + password);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AccountDTO>();
                    readTask.Wait();
                    account = readTask.Result;
                }
            }
            return account;
        }
    }
}
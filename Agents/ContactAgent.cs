using ContactAPIPOC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;

namespace Agents
{
    public class ContactAgent : IContactAgent
    {
        #region Variables
        readonly Uri baseAddress = new Uri("http://localhost:59351/api");
        HttpClient client; 
        #endregion

        #region Constructors
        public ContactAgent()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        #endregion
        #region Public Methods
        public List<ContactAPIMaster> GetContactDetails()
        {
            List<ContactAPIMaster> customers = new List<ContactAPIMaster>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/ContactMasters/").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<ContactAPIMaster>>(data);
            }
            return customers;
        }
        public bool CreateNewContact(ContactAPIMaster contact)
        {
            string data = JsonConvert.SerializeObject(contact);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/ContactMasters", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        
        public ContactAPIMaster GetContactDetailsById(int id)
        {
            ContactAPIMaster customers = new ContactAPIMaster();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/ContactMasters/"+ id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<ContactAPIMaster>(data);
            }
            return customers;
        }
        public bool EditContact(ContactAPIMaster contact)
        {
            string data = JsonConvert.SerializeObject(contact);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/ContactMasters", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public bool DeleteDetailsById(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/ContactMasters/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                
            }
            return true;
        }
        #endregion
    }
}

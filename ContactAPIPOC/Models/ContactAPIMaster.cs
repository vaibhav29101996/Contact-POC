using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactAPIPOC.Models
{
    public class ContactAPIMaster
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public Nullable<bool> ShowStatus { get; set; }
    }
}
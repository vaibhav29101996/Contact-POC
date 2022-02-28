using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IContactService
    {
        List<ContactMaster> GetContactDetails();
        bool AddContactDetails(ContactMaster contact);
        ContactMaster DeleteContactById(int id);
        bool EditContactDetailsById(int id);
        ContactMaster GetContactdetailsbyId(int id);
    }
}

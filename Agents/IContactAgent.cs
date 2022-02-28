using ContactAPIPOC.Models;
using System.Collections.Generic;

namespace Agents
{
    public interface IContactAgent
    {
        List<ContactAPIMaster> GetContactDetails();
        bool CreateNewContact(ContactAPIMaster contact);
        ContactAPIMaster GetContactDetailsById(int id);
        bool EditContact(ContactAPIMaster contact);
        bool DeleteDetailsById(int id);
    }
}

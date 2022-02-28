
using Data;
using Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ContactService : IContactService
    {
        #region Private Variables
        private readonly IContactRepository<ContactMaster> _contactRepository;
        #endregion

        #region Constructor
        public ContactService(IContactRepository<ContactMaster> contactRepository)
        {
            _contactRepository = contactRepository;
        }
        #endregion

        #region Public Methods

        public List<ContactMaster> GetContactDetails()
        {
           List<ContactMaster> contactMasterList = _contactRepository.Table.ToList();

            return contactMasterList;
        }
        public bool AddContactDetails(ContactMaster contact)
        {
            try
            {
                contact.ShowStatus = true;
                contact.ModifiedDate = DateTime.UtcNow;
                contact.CreatedDate = DateTime.UtcNow;
                _contactRepository.Create(contact);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditContactDetailsById(int id)
        {
            bool isUpdated;
            ContactMaster contactMaster = GetContactdetailsbyId(id);
            if (contactMaster == null)
            {
                return false;
            }
            else
            {
                 _contactRepository.Update(contactMaster);
                isUpdated = true;
            }
            return isUpdated;
        }
        public ContactMaster DeleteContactById(int id)
        {
            ContactMaster contactMaster = GetContactdetailsbyId(id);
            if (contactMaster == null)
            {
                return null;
            }
            else
            {
                contactMaster.ShowStatus = false;
                _contactRepository.Update(contactMaster);
            }
            return contactMaster;
        }
        public ContactMaster GetContactdetailsbyId(int id)
        {
            ContactMaster contactMaster = _contactRepository.Table.FirstOrDefault(r => r.ContactId == id);
            return contactMaster;
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using ContactAPIPOC.Models;
using Data;
using Services;
using ContactMaster = Data.ContactMaster;

namespace ContactAPIPOC.Controllers
{
    public class ContactMastersController : ApiController
    {
        #region Private Variables
        private readonly IContactService _service;
        #endregion

        #region Constructor
        public ContactMastersController(IContactService service)
        {
            _service = service;
        }
        #endregion

       

        // GET: api/ContactMasters/5
        [ResponseType(typeof(ContactMaster))]
        public IHttpActionResult GetContactMaster()
        {
            List<ContactMaster> contactMaster = _service.GetContactDetails();

            return Ok(contactMaster);
        }
        
        
        [ResponseType(typeof(ContactMaster))]
        public IHttpActionResult GetContactMasterById(int id)
        {
            ContactMaster contactMaster = _service.GetContactdetailsbyId(id);

            return Ok(contactMaster);
        }

        // PUT: api/ContactMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContactMaster(int id)
        {
            bool isUpdated = _service.EditContactDetailsById(id);
            if (!isUpdated)
            {
                return NotFound();
            }
            else
            {
                return Ok(isUpdated);
            }
        }

        // POST: api/ContactMasters
        [ResponseType(typeof(ContactAPIMaster))]
        public IHttpActionResult PostContactMaster(ContactMaster contactMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool isContactAdded = _service.AddContactDetails(contactMaster);
            if (isContactAdded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/ContactMasters/5
        [ResponseType(typeof(ContactMaster))]
        public IHttpActionResult DeleteContactMaster(int id)
        {
            ContactMaster contact = _service.DeleteContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(contact);
            }
        }
        
        
    }
}
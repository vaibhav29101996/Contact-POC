using Agents;
using ContactAPIPOC.Models;
using ContactPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactPOC.Controllers
{
    public class ContactController : Controller
    {
        #region Private Variables
        private readonly IContactAgent _contactAgent;
        #endregion

        #region Constructor
        public ContactController(IContactAgent contactAgent)
        {
            _contactAgent = contactAgent;
        }
        #endregion

        #region Public Methods
        // GET: Contact
        public ActionResult GetContactDetails()
        {
            List<ContactAPIMaster> contactDetails = _contactAgent.GetContactDetails();
            return View("_GridContactDetails", contactDetails);
        }

        // GET: Contact/Details/5
        public ActionResult Create()
        {
            return View("CreateContact");
        }

        //GET: Contact/Create
        [HttpPost]
        public ActionResult Create(ContactAPIMaster contactMaster)
        {
            bool IsAdded = _contactAgent.CreateNewContact(contactMaster);
            if (IsAdded)
            {
                List<ContactAPIMaster> contactDetails = _contactAgent.GetContactDetails();
                return View("_GridContactDetails", contactDetails);
            }
            else
            {
                return View("ErrorPage");
            }
        }

        

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            ContactAPIMaster contact = _contactAgent.GetContactDetailsById(id);
            return View("CreateContact", contact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(ContactAPIMaster contactMaster)
        {
            bool IsUpdated = _contactAgent.EditContact(contactMaster);
            if (IsUpdated)
            {
                List<ContactAPIMaster> contactDetails = _contactAgent.GetContactDetails();
                return View("_GridContactDetails", contactDetails);
            }
            else
            {
                return View("ErrorPage");
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
#endregion
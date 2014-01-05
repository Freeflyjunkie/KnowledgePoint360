using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyAddressBook.Models;
using MyAddressBook.DAL;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using MyAddressBook.ViewModels;


namespace MyAddressBook.Controllers
{
    public class ContactController : Controller
    {        
        public AddressBookContext db = new AddressBookContext();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AddressBook_Read()
        {
            IEnumerable<AddressBookViewModel> addressbooks = GetAddressBooks();
            return Json(addressbooks, JsonRequestBehavior.AllowGet);
        }       

        public JsonResult Contacts_Read([DataSourceRequest]DataSourceRequest request, int selectedAddressBook)
        {
            IEnumerable<ContactViewModel> contacts = GetContacts(selectedAddressBook);
            return Json(contacts.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Contact_Read([DataSourceRequest]DataSourceRequest request, int contactid)
        {
            IEnumerable<ContactAddressViewModel> addresses = GetContact(contactid);
            return Json(addresses.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<AddressBookViewModel> GetAddressBooks()
        {
            return db.AddressBooks
                .Select(ab => new AddressBookViewModel { AddressBookID = ab.AddressBookID, Description = ab.Description });                
        }

        private IEnumerable<ContactViewModel> GetContacts(int selectedAddressBook)
        {            
            return db.AddressBookContacts
                .Where(abc => abc.AddressBookID == selectedAddressBook)                
                .Select(abc => new ContactViewModel
                    {
                        ContactID = abc.Contact.ContactID,
                        FirstName = abc.Contact.FirstName,
                        LastName = abc.Contact.LastName,
                        PersonalImageUrl = abc.Contact.PersonalImageUrl
                    });        
        }

        private IEnumerable<ContactAddressViewModel> GetContact(int contactid)
        {
            return db.Contacts
                .Where(c => c.ContactID == contactid)
                .Select(c => new ContactAddressViewModel { Address = c.Address, City = c.City, Country = c.Country, Postcode = c.Postcode });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //// GET: /Contact/
        //public ActionResult Index()
        //{
        //    return View(db.Contacts.ToList());
        //}

        //// GET: /Contact/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Contact contact = db.Contacts.Find(id);
        //    if (contact == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contact);
        //}

        //// GET: /Contact/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: /Contact/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="ContactID,FirstName,LastName,Address,City,Postcode,Country,PersonalImageUrl")] Contact contact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Contacts.Add(contact);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(contact);
        //}

        //// GET: /Contact/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Contact contact = db.Contacts.Find(id);
        //    if (contact == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contact);
        //}

        //// POST: /Contact/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="ContactID,FirstName,LastName,Address,City,Postcode,Country,PersonalImageUrl")] Contact contact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(contact).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(contact);
        //}

        //// GET: /Contact/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Contact contact = db.Contacts.Find(id);
        //    if (contact == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contact);
        //}

        //// POST: /Contact/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Contact contact = db.Contacts.Find(id);
        //    db.Contacts.Remove(contact);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

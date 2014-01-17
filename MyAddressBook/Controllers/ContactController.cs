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
using System.Text;


namespace MyAddressBook.Controllers
{
    public class ContactController : Controller
    {        
        public AddressBookContext db = new AddressBookContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStarInformation(string imgControlID)
        {
            StringBuilder stars = new StringBuilder();

            switch (imgControlID)
            {
                case "imgRickMartin":
                    stars.Append("<div>");
                    stars.Append("<div title='Name'>Ricky Martin</div>");
                    stars.Append("<div title='Description'>Born December 24, 1971, in San Juan, Puerto Rico, Ricky Martin began appearing in commercials at age six. He was a member of teen singing group Menudo until he turned 18. After finishing high school, he appeared on stage and television while also pursuing his solo music career. His debut English album and single were hugely successful. He continues to make music in both Spanish and English today.</div>");
                    stars.Append("</div>");
                    break;

                case "imgHelenHunt":
                    stars.Append("<div>");
                    stars.Append("<div title='Name'>Helen Hunt</div>");
                    stars.Append("<div title='Description'>Born on June 15, 1963, in Culver City, California. Her first role was at age 9 in the 1973 TV movie, Pioneer Woman. Hunt later appeared in the acclaimed medical drama St. Elsewhere and starred opposite Paul Reiser in the sitcom Mad About You, for which she won four Emmys. In 1996, Hunt starred in the box-office hit Twister and in 1997 she won the Best Actress Academy Award for As Good As It Gets.</div>");
                    stars.Append("</div>");
                    break;

                case "imgJodieFoster":
                    stars.Append("<div>");
                    stars.Append("<div title='Name'>Jodie Foster</div>");
                    stars.Append("<div title='Description'>American actress, director and producer Jodie Foster was born on November 19, 1962, in Los Angeles, California. Foster received an Oscar nomination at age 12 for her role as a child prostitute in Martin Scorsese's film Taxi Driver (1976), and went on to win a Golden Globe (best actress) and Academy Award for The Accused (1988). She then starred in the popular film The Silence of the Lambs (1991).</div>");
                    stars.Append("</div>");
                    break;

                case "imgSallyField":
                    stars.Append("<div>");
                    stars.Append("<div title='Name'>Sally Field</div>");
                    stars.Append("<div title='Description'>Sally Field is an American actress born on November 6, 1946 in Pasadena, California. Her big break came when she played the lead role in the TV sitcom Gidget (1965). Field next appeared in the hit TV series' The Flying Nun (1967) and Smokey and the Bandit (1977). Field won Emmy Awards for her performances in Sybil (1976), Beautiful (2000) and Saturday Evening Post (2007),</div>");
                    stars.Append("</div>");
                    break;

                case "imgBradPitt":
                    stars.Append("<div>");
                    stars.Append("<div title='Name'>Brad Pitt</div>");
                    stars.Append("<div title='Description'>Actor and producer Brad Pitt was born on December 18, 1963, in Shawnee, Oklahoma. Pitt's first jobs came in television in the late 1980s. Pitt made his big-screen debut in 1989's horror film Cutting Class, but his next few films failed to boost his acting credibility. His role in 1994's Legends of the Fall, however, helped secured his current place as a Hollywood staple.</div>");
                    stars.Append("</div>");
                    break;

                case "imgSandraBullcock":
                    stars.Append("<div>");
                    stars.Append("<div title='Name'>Sandra Bullock</div>");
                    stars.Append("<div title='Description'>Born July 26, 1964, in Arlington, Virginia, Sandra Bullock made her first stage appearance at age 5 in an opera in Germany. She first became widely known for her role in the 1994 hit Speed. She has since starred in many more films, and won an Academy Award for Best Actress and a Golden Globe for her performance in The Blind Side (2009), based on the true-life story of football player Michael Oher.</div>");
                    stars.Append("</div>");
                    break;

                case "imgBillNye":
                    stars.Append("<div>");
                    stars.Append("<div title='Name'>Bill Nye</div>");
                    stars.Append("<div title='Description'>Bill Nye, born on November 27, 1955, grew up in Washington, D.C., where he received a mediocre education until hard work and a smalls scholarship got him into a good private school. From there he went on to Cornell University, moved to Seattle to work as a mechanical engineer for the Boeing Company and eventually became a comedy show writer and performer.</div>");
                    stars.Append("</div>");
                    break;

                case "imgJackNicholson":
                    stars.Append("<div>");
                    stars.Append("<div title='Name'>Jack Nicholson</div>");
                    stars.Append("<div title='Description'>Born on April 22, 1937, in Neptune, New Jersey, Jack Nicholson is one of the most prominent American motion-picture actors of his generation. Nicholson's career has contained some of the seminal film in Hollywood history, including Chinatown and One Flew Over the Cuckoo's Nest, and his role as Jack in Stanley Kubrick's The Shining has become iconic.</div>");
                    stars.Append("</div>");
                    break;

                default:
                    break;
            }            

            Response.Write(stars.ToString());
            return null;
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

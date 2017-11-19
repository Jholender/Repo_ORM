using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Repository;
using WebApplication4.Service;

namespace WebApplication4.Controllers
{
    public class ContactFormController : Controller
    {
        private EmailServis _emailServis;
        private ContactFormRepository _contactRepository;
        public ContactFormController()
        {
            _emailServis = new EmailServis();
            _contactRepository = new ContactFormRepository();
        }
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: ContactForm
        public ActionResult Index()
        {
            return View(_contactRepository.GetWhere(x => x.Id>0));
        }

        // GET: ContactForm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = _contactRepository.GetWhere(x =>x.Id==id.Value).FirstOrDefault();
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // GET: ContactForm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.Create(contactForm);
                var message = _emailServis.CreateMailMessage(contactForm);
                _emailServis.SendEmail(message);
                return RedirectToAction("Index");
            }

            return View(contactForm);
        }

        

       
        // GET: ContactForm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = _contactRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // POST: ContactForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactForm contactForm = _contactRepository.GetWhere(x => x.Id ==id).FirstOrDefault();
            _contactRepository.Delete(contactForm);
            return RedirectToAction("Index");
        }

        
    }
}

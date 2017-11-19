using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class UzytkownicyDBsController : Controller
    {
        private Context db = new Context();

        // GET: UzytkownicyDBs
        public ActionResult Index()
        {
            return View(db.Zadanie.ToList());
        }

        // GET: UzytkownicyDBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UzytkownicyDB uzytkownicyDB = db.Zadanie.Find(id);
            if (uzytkownicyDB == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownicyDB);
        }

        // GET: UzytkownicyDBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UzytkownicyDBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,temat,tresc")] UzytkownicyDB uzytkownicyDB)
        {
            if (ModelState.IsValid)
            {
                db.Zadanie.Add(uzytkownicyDB);
                db.SaveChanges();
                //konfiguracja i autoryzacja ze skrzynką mailowa
                var smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = true,
                    Credentials =
                    new NetworkCredential("gym550182@gmail.com", "!QAZ2wsx#EDC")

                };
                //tworzenie nowej wiadomosci email
                var mailMessage = new MailMessage
                {
                    Sender = new MailAddress("gym550182@gmail.com"),
                    From = new MailAddress("gym550182@gmail.com"),
                    To = {"gym550182@gmail.com"},
                    Subject = uzytkownicyDB.temat
    ,
                    Body = uzytkownicyDB.tresc,
                    IsBodyHtml = true

                };
                smtpClient.Send(mailMessage);
                return RedirectToAction("Index");
            }

            return View(uzytkownicyDB);
        }

        // GET: UzytkownicyDBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UzytkownicyDB uzytkownicyDB = db.Zadanie.Find(id);
            if (uzytkownicyDB == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownicyDB);
        }

        // POST: UzytkownicyDBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,temat,tresc")] UzytkownicyDB uzytkownicyDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uzytkownicyDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uzytkownicyDB);
        }

        // GET: UzytkownicyDBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UzytkownicyDB uzytkownicyDB = db.Zadanie.Find(id);
            if (uzytkownicyDB == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownicyDB);
        }

        // POST: UzytkownicyDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UzytkownicyDB uzytkownicyDB = db.Zadanie.Find(id);
            db.Zadanie.Remove(uzytkownicyDB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

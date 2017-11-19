using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ZadanieDBsController : Controller
    {
        private Context db = new Context();

        // GET: ZadanieDBs
        public ActionResult Index()
        {
            return View(db.Zadanie.ToList());
        }

        // GET: ZadanieDBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZadanieDB zadanieDB = db.Zadanie.Find(id);
            if (zadanieDB == null)
            {
                return HttpNotFound();
            }
            return View(zadanieDB);
        }

        // GET: ZadanieDBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZadanieDBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ZadanieDB zadanieDB)
        {
            zadanieDB.DataWprow = DateTime.Now;
            if (ModelState.IsValid)
            {
                zadanieDB.DataWprow = DateTime.Now;
                zadanieDB.DataModyf = DateTime.Now;
                db.Zadanie.Add(zadanieDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zadanieDB);
        }

        // GET: ZadanieDBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZadanieDB zadanieDB = db.Zadanie.Find(id);
            if (zadanieDB == null)
            {
                return HttpNotFound();
            }
            return View(zadanieDB);
        }

        // POST: ZadanieDBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ZadanieDB zadanieDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zadanieDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zadanieDB);
        }

        // GET: ZadanieDBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZadanieDB zadanieDB = db.Zadanie.Find(id);
            if (zadanieDB == null)
            {
                return HttpNotFound();
            }
            return View(zadanieDB);
        }

        // POST: ZadanieDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZadanieDB zadanieDB = db.Zadanie.Find(id);
            db.Zadanie.Remove(zadanieDB);
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

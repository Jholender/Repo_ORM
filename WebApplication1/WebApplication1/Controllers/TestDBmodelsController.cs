using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TestDBmodelsController : Controller
    {
        private Models.AppContext db = new Models.AppContext();

        // GET: TestDBmodels
        public ActionResult Index()
        {
            return View(db.TestDBmodels.ToList());
        }

        // GET: TestDBmodels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestDBmodel testDBmodel = db.TestDBmodels.Find(id);
            if (testDBmodel == null)
            {
                return HttpNotFound();
            }
            return View(testDBmodel);
        }

        // GET: TestDBmodels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestDBmodels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Prop")] TestDBmodel testDBmodel)
        {
            if (ModelState.IsValid)
            {
                db.TestDBmodels.Add(testDBmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testDBmodel);
        }

        // GET: TestDBmodels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestDBmodel testDBmodel = db.TestDBmodels.Find(id);
            if (testDBmodel == null)
            {
                return HttpNotFound();
            }
            return View(testDBmodel);
        }

        // POST: TestDBmodels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Prop")] TestDBmodel testDBmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testDBmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testDBmodel);
        }

        // GET: TestDBmodels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestDBmodel testDBmodel = db.TestDBmodels.Find(id);
            if (testDBmodel == null)
            {
                return HttpNotFound();
            }
            return View(testDBmodel);
        }

        // POST: TestDBmodels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestDBmodel testDBmodel = db.TestDBmodels.Find(id);
            db.TestDBmodels.Remove(testDBmodel);
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

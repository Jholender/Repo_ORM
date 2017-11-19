using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Repository;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class aktorziesController : Controller
    {
        private ActRepository _actRepo;

        public aktorziesController()
        {
            _actRepo = new ActRepository();
        }

        // GET: aktorzies
        public ActionResult Index()
        {
            return View(_actRepo.GetWhere(x =>x.Id>0));
        }

        // GET: aktorzies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aktorzy aktorzy = _actRepo.GetWhere(x => x.Id ==id.Value).FirstOrDefault();
            if (aktorzy == null)
            {
                return HttpNotFound();
            }
            return View(aktorzy);
        }

        // GET: aktorzies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: aktorzies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(aktorzy aktorzy)
        {
            if (ModelState.IsValid)
            {
                _actRepo.Create(aktorzy);


                return RedirectToAction("Index");
            }

            return View(aktorzy);
        }

        // GET: aktorzies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aktorzy aktorzy = _actRepo.GetWhere(x => x.Id == id.Value).FirstOrDefault(); 
            if (aktorzy == null)
            {
                return HttpNotFound();
            }
            return View(aktorzy);
        }

        // POST: aktorzies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(aktorzy aktorzy)
        {
            if (ModelState.IsValid)
            {
                _actRepo.Update(aktorzy);
                return RedirectToAction("Index");
            }
            return View(aktorzy);
        }

        // GET: aktorzies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aktorzy aktorzy = _actRepo.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (aktorzy == null)
            {
                return HttpNotFound();
            }
            return View(aktorzy);
        }

        // POST: aktorzies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            aktorzy aktorzy = _actRepo.GetWhere(x => x.Id == id).FirstOrDefault();
            _actRepo.Delete(aktorzy);

            return RedirectToAction("Index");
        }

       
    }
}

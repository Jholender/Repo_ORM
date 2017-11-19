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
    public class filmiesController : Controller
    {
        private FilmRepository _filmRepo;

        public filmiesController()
        {
            _filmRepo = new FilmRepository();
        }
        

        // GET: filmies
        public ActionResult Index()
        {
            return View(_filmRepo.GetWhere(x => x.Id > 0));
        }

        // GET: filmies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            filmy filmy = _filmRepo.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (filmy == null)
            {
                return HttpNotFound();
            }
            return View(filmy);
        }

        // GET: filmies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: filmies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(filmy filmy)
        {
            if (ModelState.IsValid)
            {
                _filmRepo.Create(filmy);
                return RedirectToAction("Index");
            }

            return View(filmy);
        }

        // GET: filmies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            filmy filmy = _filmRepo.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (filmy == null)
            {
                return HttpNotFound();
            }
            return View(filmy);
        }

        // POST: filmies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(filmy filmy)
        {
            if (ModelState.IsValid)
            {
                _filmRepo.Update(filmy);
                return RedirectToAction("Index");
            }
            return View(filmy);
        }

        // GET: filmies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            filmy filmy = _filmRepo.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (filmy == null)
            {
                return HttpNotFound();
            }
            return View(filmy);
        }

        // POST: filmies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            filmy filmy = _filmRepo.GetWhere(x => x.Id == id).FirstOrDefault();
            _filmRepo.Delete(filmy);
            return RedirectToAction("Index");
        }

       
    }
}

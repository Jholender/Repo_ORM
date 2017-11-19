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
    public class rezyserziesController : Controller
    {
        private RezRepository _rezRepo;

        public rezyserziesController()
        {
            _rezRepo = new RezRepository();
        }

        // GET: rezyserzies
        public ActionResult Index()
        {
            return View(_rezRepo.GetWhere(x => x.Id > 0));
        }

        // GET: rezyserzies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rezyserzy rezyserzy = _rezRepo.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (rezyserzy == null)
            {
                return HttpNotFound();
            }
            return View(rezyserzy);
        }

        // GET: rezyserzies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rezyserzies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ImieRez,NazwiRez")] rezyserzy rezyserzy)
        {
            if (ModelState.IsValid)
            {
                _rezRepo.Create(rezyserzy);
                return RedirectToAction("Index");
            }

            return View(rezyserzy);
        }

        // GET: rezyserzies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rezyserzy rezyserzy = _rezRepo.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (rezyserzy == null)
            {
                return HttpNotFound();
            }
            return View(rezyserzy);
        }

        // POST: rezyserzies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ImieRez,NazwiRez")] rezyserzy rezyserzy)
        {
            if (ModelState.IsValid)
            {
                _rezRepo.Update(rezyserzy);
                return RedirectToAction("Index");
            }
            return View(rezyserzy);
        }

        // GET: rezyserzies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rezyserzy rezyserzy = _rezRepo.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (rezyserzy == null)
            {
                return HttpNotFound();
            }
            return View(rezyserzy);
        }

        // POST: rezyserzies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rezyserzy rezyserzy = _rezRepo.GetWhere(x => x.Id == id).FirstOrDefault();
            _rezRepo.Delete(rezyserzy);
            return RedirectToAction("Index");
        }

        
        }
    }


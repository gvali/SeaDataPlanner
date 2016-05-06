using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interface;
using DAL.Repository;
using Domain;

namespace Web.Controllers
{
    public class CruisesController : Controller
    {
        //        private DataBaseContext db = new DataBaseContext();
        private ICruiseRepository _cruisesRepository = new CruiseRepository(new DataBaseContext());

        // GET: Cruises
        public ActionResult Index()
        {
            //            return System.Web.UI.WebControls.View(db.Cruises.ToList());
            return View(_cruisesRepository.All);

        }

        // GET: Cruises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
//            Cruise cruise = db.Cruises.Find(id);
            Cruise cruise = _cruisesRepository.GetById(id);
            if (cruise == null)
            {
                return HttpNotFound();
            }
            return View(cruise);
        }

        // GET: Cruises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cruises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CruiseId,CruiseName,PersonId")] Cruise cruise)
        {
            if (ModelState.IsValid)
            {
//                db.Cruises.Add(cruise);
//                db.SaveChanges();
                _cruisesRepository.Add(cruise);
                _cruisesRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cruise);
        }

        // GET: Cruises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
//            Cruise cruise = db.Cruises.Find(id);
            Cruise cruise = _cruisesRepository.GetById(id);

            if (cruise == null)
            {
                return HttpNotFound();
            }
            return View(cruise);
        }

        // POST: Cruises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CruiseId,CruiseName,PersonId")] Cruise cruise)
        {
            if (ModelState.IsValid)
            {
//                db.Entry(cruise).State = EntityState.Modified;
//                db.SaveChanges();
                _cruisesRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cruise);
        }

        // GET: Cruises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
//            Cruise cruise = db.Cruises.Find(id);
            Cruise cruise = _cruisesRepository.GetById(id);
            if (cruise == null)
            {
                return HttpNotFound();
            }
            return View(cruise);
        }

        // POST: Cruises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
//            Cruise cruise = db.Cruises.Find(id);
            Cruise cruise = _cruisesRepository.GetById(id);
//            db.Cruises.Remove(cruise);
//            db.SaveChanges();
            _cruisesRepository.Delete(cruise);
            _cruisesRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
//                db.Dispose();
                _cruisesRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

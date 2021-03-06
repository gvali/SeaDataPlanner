﻿using System;
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
    public class PersonController : Controller
    {
        //private DataBaseContext db = new DataBaseContext();

        private IPersonRepository _personRepository = new PersonRepository(new DataBaseContext());
        
        // GET: Person
        public ActionResult Index()
        {
//            return View(db.Persons.ToList());
            return View(_personRepository.All);
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Person person = db.Persons.Find(id);
            Person person = _personRepository.GetById();
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,FirstName,LastName")] Person person)
        {
            if (ModelState.IsValid)
            {
                //db.Persons.Add(person);
                _personRepository.Add(person);
                //db.SaveChanges();
                _personRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
//            Person person = db.Persons.Find(id);
            Person person = _personRepository.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,FirstName,LastName")] Person person)
        {
            if (ModelState.IsValid)
            {
                //                db.Entry(person).State = EntityState.Modified;

                _personRepository.SaveChanges();
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
//            Person person = db.Persons.Find(id);
            Person person = _personRepository.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //            Person person = db.Persons.Find(id);
            Person person = _personRepository.GetById(id);
            _personRepository.Delete(person);
            _personRepository.SaveChanges();
 //           db.Persons.Remove(person);
 //          db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
//                db.Dispose();
                _personRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CidicomPrototype.Models;
using CidicomPrototype.DAL;

namespace CidicomPrototype.Controllers
{
    public class TecnicoController : Controller
    {
        private CidicomContext db = new CidicomContext();

        //
        // GET: /Tecnico/

        public ActionResult Index()
        {
            return View(db.Tecnicos.ToList());
        }

        //
        // GET: /Tecnico/Details/5

        public ActionResult Details(int id = 0)
        {
            Tecnico tecnico = db.Tecnicos.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        //
        // GET: /Tecnico/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tecnico/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                db.Tecnicos.Add(tecnico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tecnico);
        }

        //
        // GET: /Tecnico/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tecnico tecnico = db.Tecnicos.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        //
        // POST: /Tecnico/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tecnico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tecnico);
        }

        //
        // GET: /Tecnico/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tecnico tecnico = db.Tecnicos.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        //
        // POST: /Tecnico/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tecnico tecnico = db.Tecnicos.Find(id);
            db.Tecnicos.Remove(tecnico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
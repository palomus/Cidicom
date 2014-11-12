using System;
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
    public class ServiciosController : Controller
    {
        private CidicomContext db = new CidicomContext();

        //
        // GET: /Servicios/

        public ActionResult Index(int id = 0)
        {
            var servicios = db.Servicios.Include(s => s.Activos);
            
            if (servicios == null)
            {
                return HttpNotFound();
            }
            if (id != 0)
            {
                return View(servicios.Where(x => x.IDActivos == id).ToList());
            }
            else
            {
                return View(servicios.ToList()); 
            }
        }

        //
        // GET: /Servicios/Details/5

        public ActionResult Details(int id = 0)
        {
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        //
        // GET: /Servicios/Create

        public ActionResult Create()
        {
            ViewBag.IDActivos = new SelectList(db.Activos, "IDActivos", "nameActivos");
            return View();
        }

        //
        // POST: /Servicios/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Servicios.Add(servicios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDActivos = new SelectList(db.Activos, "IDActivos", "nameActivos", servicios.IDActivos);
            return View(servicios);
        }

        //
        // GET: /Servicios/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDActivos = new SelectList(db.Activos, "IDActivos", "nameActivos", servicios.IDActivos);
            return View(servicios);
        }

        //
        // POST: /Servicios/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Servicios servicios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDActivos = new SelectList(db.Activos, "IDActivos", "nameActivos", servicios.IDActivos);
            return View(servicios);
        }

        //
        // GET: /Servicios/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return HttpNotFound();
            }
            return View(servicios);
        }

        //
        // POST: /Servicios/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicios servicios = db.Servicios.Find(id);
            db.Servicios.Remove(servicios);
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
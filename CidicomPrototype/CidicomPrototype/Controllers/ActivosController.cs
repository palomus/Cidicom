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
    public class ActivosController : Controller
    {
        private CidicomContext db = new CidicomContext();

        //
        // GET: /Activos/

        public ActionResult Index(int id = 0)
        {
            var activos = db.Activos.Include(a => a.Sitios);
            
            if (activos == null)
            {
                return HttpNotFound();
            }
            if (id != 0)
            {
                return View(activos.Where(x => x.IDSitios == id).ToList());
            }
            else
            {
                return View(activos.ToList());
            }
        }

        //
        // GET: /Activos/Details/5

        public ActionResult Details(int id = 0)
        {
            Activos activos = db.Activos.Find(id);
            if (activos == null)
            {
                return HttpNotFound();
            }
            return View(activos);
        }

        //
        // GET: /Activos/Create

        public ActionResult Create()
        {
            ViewBag.IDSitios = new SelectList(db.Sitios, "IDSitios", "nameSitios");
            return View();
        }

        //
        // POST: /Activos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Activos activos)
        {
            if (ModelState.IsValid)
            {
                db.Activos.Add(activos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDSitios = new SelectList(db.Sitios, "IDSitios", "nameSitios", activos.IDSitios);
            return View(activos);
        }

        //
        // GET: /Activos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Activos activos = db.Activos.Find(id);
            if (activos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDSitios = new SelectList(db.Sitios, "IDSitios", "nameSitios", activos.IDSitios);
            return View(activos);
        }

        //
        // POST: /Activos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Activos activos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDSitios = new SelectList(db.Sitios, "IDSitios", "nameSitios", activos.IDSitios);
            return View(activos);
        }

        //
        // GET: /Activos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Activos activos = db.Activos.Find(id);
            if (activos == null)
            {
                return HttpNotFound();
            }
            return View(activos);
        }

        //
        // POST: /Activos/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activos activos = db.Activos.Find(id);
            db.Activos.Remove(activos);
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
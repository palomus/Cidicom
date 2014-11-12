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
    public class TareasController : Controller
    {
        private CidicomContext db = new CidicomContext();

        //
        // GET: /Tareas/

        public ActionResult Index(int id =0)
        {
            var tareas = db.Tareas.Include(t => t.Servicios).Include(t => t.Tecnico);
            
            if (tareas == null)
            {
                return HttpNotFound();
            }
            if (id != 0)
            {
                return View(tareas.Where(x => x.IDServicios == id).ToList());
            }
            else
            {
                return View(tareas.ToList());
            }
        }

        //
        // GET: /Tareas/Details/5

        public ActionResult Details(int id = 0)
        {
            Tareas tareas = db.Tareas.Find(id);
            if (tareas == null)
            {
                return HttpNotFound();
            }
            return View(tareas);
        }

        //
        // GET: /Tareas/Create

        public ActionResult Create()
        {
            ViewBag.IDServicios = new SelectList(db.Servicios, "IDServicios", "nameServicios");
            ViewBag.IDTecnico = new SelectList(db.Tecnicos, "IDTecnico", "NameTecnico");
            return View();
        }

        //
        // POST: /Tareas/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tareas tareas)
        {
            if (ModelState.IsValid)
            {
                db.Tareas.Add(tareas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDServicios = new SelectList(db.Servicios, "IDServicios", "nameServicios", tareas.IDServicios);
            ViewBag.IDTecnico = new SelectList(db.Tecnicos, "IDTecnico", "NameTecnico", tareas.IDTecnico);
            return View(tareas);
        }

        //
        // GET: /Tareas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tareas tareas = db.Tareas.Find(id);
            if (tareas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDServicios = new SelectList(db.Servicios, "IDServicios", "nameServicios", tareas.IDServicios);
            ViewBag.IDTecnico = new SelectList(db.Tecnicos, "IDTecnico", "NameTecnico", tareas.IDTecnico);
            return View(tareas);
        }

        //
        // POST: /Tareas/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tareas tareas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tareas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDServicios = new SelectList(db.Servicios, "IDServicios", "nameServicios", tareas.IDServicios);
            ViewBag.IDTecnico = new SelectList(db.Tecnicos, "IDTecnico", "NameTecnico", tareas.IDTecnico);
            return View(tareas);
        }

        //
        // GET: /Tareas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tareas tareas = db.Tareas.Find(id);
            if (tareas == null)
            {
                return HttpNotFound();
            }
            return View(tareas);
        }

        //
        // POST: /Tareas/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tareas tareas = db.Tareas.Find(id);
            db.Tareas.Remove(tareas);
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
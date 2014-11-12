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
    public class SitiosController : Controller
    {
        private CidicomContext db = new CidicomContext();

        //
        // GET: /Default1/
        // ~/Index/2
        public ActionResult Index(int id = 0)
        {
            var sitios = db.Sitios.Include(s => s.Clientes);
            if (sitios == null)
            {
                return HttpNotFound();
            }
            if (id != 0)
            {
                return View(sitios.Where(x => x.IDCliente == id).ToList());
            }
            else
            {
                return View(sitios.ToList());
            }
        }



        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            Sitios sitios = db.Sitios.Find(id);
            if (sitios == null)
            {
                return HttpNotFound();
            }
            return View(sitios);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "NameCliente");
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sitios sitios)
        {
            if (ModelState.IsValid)
            {
                db.Sitios.Add(sitios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "NameCliente", sitios.IDCliente);
            return View(sitios);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sitios sitios = db.Sitios.Find(id);
            if (sitios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "NameCliente", sitios.IDCliente);
            return View(sitios);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sitios sitios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sitios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "NameCliente", sitios.IDCliente);
            return View(sitios);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sitios sitios = db.Sitios.Find(id);
            if (sitios == null)
            {
                return HttpNotFound();
            }
            return View(sitios);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sitios sitios = db.Sitios.Find(id);
            db.Sitios.Remove(sitios);
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
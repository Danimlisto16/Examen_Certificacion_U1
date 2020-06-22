using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BdBiblioteca;

namespace Examen_Certificacion_U1.Controllers
{
    public class LIBROesController : Controller
    {
        private BIBLIOTECAEntities db = new BIBLIOTECAEntities();

        // GET: LIBROes
        public ActionResult Index()
        {
            var lIBRO = db.LIBRO.Include(l => l.CATEGORIA1);
            return View(lIBRO.ToList());
        }

        // GET: LIBROes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBRO lIBRO = db.LIBRO.Find(id);
            if (lIBRO == null)
            {
                return HttpNotFound();
            }
            return View(lIBRO);
        }

        // GET: LIBROes/Create
        public ActionResult Create()
        {
            ViewBag.categoria = new SelectList(db.CATEGORIA, "id_categoria", "nombre");
            return View();
        }

        // POST: LIBROes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_libro,titulo,autor,ISBN,fechaPublicacion,ejemplar,categoria")] LIBRO lIBRO)
        {
            if (ModelState.IsValid)
            {
                db.LIBRO.Add(lIBRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoria = new SelectList(db.CATEGORIA, "id_categoria", "nombre", lIBRO.categoria);
            return View(lIBRO);
        }

        // GET: LIBROes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBRO lIBRO = db.LIBRO.Find(id);
            if (lIBRO == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoria = new SelectList(db.CATEGORIA, "id_categoria", "nombre", lIBRO.categoria);
            return View(lIBRO);
        }

        // POST: LIBROes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_libro,titulo,autor,ISBN,fechaPublicacion,ejemplar,categoria")] LIBRO lIBRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lIBRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoria = new SelectList(db.CATEGORIA, "id_categoria", "nombre", lIBRO.categoria);
            return View(lIBRO);
        }

        // GET: LIBROes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBRO lIBRO = db.LIBRO.Find(id);
            if (lIBRO == null)
            {
                return HttpNotFound();
            }
            return View(lIBRO);
        }

        // POST: LIBROes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LIBRO lIBRO = db.LIBRO.Find(id);
            db.LIBRO.Remove(lIBRO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

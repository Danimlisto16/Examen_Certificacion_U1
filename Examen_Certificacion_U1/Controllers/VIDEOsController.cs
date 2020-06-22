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
    public class VIDEOsController : Controller
    {
        private BIBLIOTECAEntities db = new BIBLIOTECAEntities();

        // GET: VIDEOs
        public ActionResult Index()
        {
            var vIDEO = db.VIDEO.Include(v => v.CATEGORIA1);
            return View(vIDEO.ToList());
        }

        // GET: VIDEOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIDEO vIDEO = db.VIDEO.Find(id);
            if (vIDEO == null)
            {
                return HttpNotFound();
            }
            return View(vIDEO);
        }

        // GET: VIDEOs/Create
        public ActionResult Create()
        {
            ViewBag.categoria = new SelectList(db.CATEGORIA, "id_categoria", "nombre");
            return View();
        }

        // POST: VIDEOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_video,titulo,fechaPublicacion,formato,duracion,categoria")] VIDEO vIDEO)
        {
            if (ModelState.IsValid)
            {
                db.VIDEO.Add(vIDEO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoria = new SelectList(db.CATEGORIA, "id_categoria", "nombre", vIDEO.categoria);
            return View(vIDEO);
        }

        // GET: VIDEOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIDEO vIDEO = db.VIDEO.Find(id);
            if (vIDEO == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoria = new SelectList(db.CATEGORIA, "id_categoria", "nombre", vIDEO.categoria);
            return View(vIDEO);
        }

        // POST: VIDEOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_video,titulo,fechaPublicacion,formato,duracion,categoria")] VIDEO vIDEO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vIDEO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoria = new SelectList(db.CATEGORIA, "id_categoria", "nombre", vIDEO.categoria);
            return View(vIDEO);
        }

        // GET: VIDEOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIDEO vIDEO = db.VIDEO.Find(id);
            if (vIDEO == null)
            {
                return HttpNotFound();
            }
            return View(vIDEO);
        }

        // POST: VIDEOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VIDEO vIDEO = db.VIDEO.Find(id);
            db.VIDEO.Remove(vIDEO);
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

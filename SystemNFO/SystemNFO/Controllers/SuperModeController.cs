using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SystemNFO.Models;

namespace SystemNFO.Controllers
{
    public class SuperModeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SuperMode
        public ActionResult Index()
        {
            return View(db.SuperModes.ToList());
        }
        public ActionResult GetModes()
        {
            var modes = db.SuperModes.ToList();
            return PartialView(modes);
        }
        // GET: SuperMode/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuperMode superMode = db.SuperModes.Find(id);
            if (superMode == null)
            {
                return HttpNotFound();
            }
            return View(superMode);
        }

        // GET: SuperMode/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperMode/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuperModeId,Ogrn,Date,Document,Vid,Category,Mode,Namemode")] SuperMode superMode)
        {
            if (ModelState.IsValid)
            {
                db.SuperModes.Add(superMode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(superMode);
        }

        // GET: SuperMode/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuperMode superMode = db.SuperModes.Find(id);
            if (superMode == null)
            {
                return HttpNotFound();
            }
            return View(superMode);
        }

        // POST: SuperMode/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuperModeId,Ogrn,Date,Document,Vid,Category,Mode,Namemode")] SuperMode superMode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(superMode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(superMode);
        }

        // GET: SuperMode/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuperMode superMode = db.SuperModes.Find(id);
            if (superMode == null)
            {
                return HttpNotFound();
            }
            return View(superMode);
        }

        // POST: SuperMode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuperMode superMode = db.SuperModes.Find(id);
            db.SuperModes.Remove(superMode);
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

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
    public class OrgCurController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrgCur
        public ActionResult Index()
        {
            return View(db.OrgCurs.ToList());
        }

        // GET: OrgCur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgCur orgCur = db.OrgCurs.Find(id);
            if (orgCur == null)
            {
                return HttpNotFound();
            }
            return View(orgCur);
        }

        // GET: OrgCur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrgCur/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrgCurId,Ogrn,Socrnameorg")] OrgCur orgCur)
        {
            if (ModelState.IsValid)
            {
                db.OrgCurs.Add(orgCur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orgCur);
        }

        // GET: OrgCur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgCur orgCur = db.OrgCurs.Find(id);
            if (orgCur == null)
            {
                return HttpNotFound();
            }
            return View(orgCur);
        }

        // POST: OrgCur/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrgCurId,Ogrn,Socrnameorg")] OrgCur orgCur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orgCur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orgCur);
        }

        // GET: OrgCur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrgCur orgCur = db.OrgCurs.Find(id);
            if (orgCur == null)
            {
                return HttpNotFound();
            }
            return View(orgCur);
        }

        // POST: OrgCur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrgCur orgCur = db.OrgCurs.Find(id);
            db.OrgCurs.Remove(orgCur);
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

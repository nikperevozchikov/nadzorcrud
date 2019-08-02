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
    public class CurController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cur
        public ActionResult Index()
        {
            return View(db.Curs.ToList());
        }
        public ActionResult GetOrganizations()
        {
            var organizations = db.Curs.ToList();
            return PartialView(organizations);
        }
        public ActionResult GetOrganizations1()
        {
            var organizations = db.Curs.ToList();
            return PartialView(organizations);
        }
        public ActionResult Index1()
        {
            return View(db.Organizations.ToList());
        }
        // GET: Cur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cur cur = db.Curs.Find(id);
            if (cur == null)
            {
                return HttpNotFound();
            }
            return View(cur);
        }

        // GET: Cur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cur/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CurId,Ogrn,Socrnameorg")] Cur cur)
        {
            if (ModelState.IsValid)
            {
                db.Curs.Add(cur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cur);
        }

        // GET: Cur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cur cur = db.Curs.Find(id);
            if (cur == null)
            {
                return HttpNotFound();
            }
            return View(cur);
        }

        // POST: Cur/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CurId,Ogrn,Socrnameorg")] Cur cur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cur);
        }

        // GET: Cur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cur cur = db.Curs.Find(id);
            if (cur == null)
            {
                return HttpNotFound();
            }
            return View(cur);
        }

        // POST: Cur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cur cur = db.Curs.Find(id);
            db.Curs.Remove(cur);
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

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
    public class OrganizationCuratorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrganizationCurator
        public ActionResult Index()
        {
            return View(db.OrganizationCurators.ToList());
        }

        // GET: OrganizationCurator/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationCurator organizationCurator = db.OrganizationCurators.Find(id);
            if (organizationCurator == null)
            {
                return HttpNotFound();
            }
            return View(organizationCurator);
        }

        // GET: OrganizationCurator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganizationCurator/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganizationCuratorId,Ogrn,Socrnameorg,FIO")] OrganizationCurator organizationCurator)
        {
            if (ModelState.IsValid)
            {
                db.OrganizationCurators.Add(organizationCurator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organizationCurator);
        }

        // GET: OrganizationCurator/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationCurator organizationCurator = db.OrganizationCurators.Find(id);
            if (organizationCurator == null)
            {
                return HttpNotFound();
            }
            return View(organizationCurator);
        }

        // POST: OrganizationCurator/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganizationCuratorId,Ogrn,Socrnameorg,FIO")] OrganizationCurator organizationCurator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizationCurator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organizationCurator);
        }

        // GET: OrganizationCurator/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationCurator organizationCurator = db.OrganizationCurators.Find(id);
            if (organizationCurator == null)
            {
                return HttpNotFound();
            }
            return View(organizationCurator);
        }

        // POST: OrganizationCurator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrganizationCurator organizationCurator = db.OrganizationCurators.Find(id);
            db.OrganizationCurators.Remove(organizationCurator);
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

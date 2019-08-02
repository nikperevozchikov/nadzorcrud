using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SystemNFO.Models;

namespace SystemNFO.Controllers
{
    public class OrganizationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //[HttpGet]
        //public ActionResult CreateEmp()
        //{ 
        //    SelectList employees = new SelectList(db.Employees, "EmployeeId", "FIO");
        //      ViewBag.Employees = employees;
         
        //}

        public ActionResult Index()
        {
            return View(db.Organizations.ToList());
        }
        public ActionResult Index2()
        {
            return View(db.Events.ToList());
        }
        public ActionResult Index4()
        {
            return View(db.Events.ToList());
        }
        public ActionResult Index3()
        {
            return View(db.SuperModes.ToList());
        }
        public ActionResult GetOrganizations()
        {
            var organizations = db.Organizations.ToList();
            return PartialView(organizations);
        }
        public ActionResult GetOrganizations1()
        {
            var organizations = db.Organizations.ToList();
            return PartialView(organizations);
        }
        public ActionResult GetOrganizations2()
        {
            var organizations = db.Organizations.ToList();
            return PartialView(organizations);
        }
        public ActionResult Index1()
        {
            return View(db.Organizations.ToList());
        }

        [HttpGet]
        public ActionResult ListOrganizations()
        {
            var organizations = db.Organizations.ToList();

            var viewModel = new ListOrganizationViewModel { Organizations = organizations };

            return View(viewModel);
        }
       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

       
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create4()
        {
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create4([Bind(Include = "EventId,Nameevent,Comment,Databegin,Status,Dataend,Dataperenos,Dataplan,Datacontrol,Nadzorfact,Result,Mode")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index4");
            }

            return View(@event);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganizationId,Ogrn,Nameorg,Socrnameorg,Status,Vidorg,Category,Risc,Mode")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Organizations.Add(organization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organization);
        }
    
        public ActionResult Create1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create1([Bind(Include = "OrganizationId,Ogrn,Nameorg,Socrnameorg,Status,Vidorg,Category,Risc,Mode")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Organizations.Add(organization);
                db.SaveChanges();
                return RedirectToAction("Index1");
            }

            return View(organization);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }
     
        public ActionResult Edit1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganizationId,Ogrn,Nameorg,Socrnameorg,Status,Vidorg,Category,Risc,Mode")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organization);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit1([Bind(Include = "OrganizationId,Ogrn,Nameorg,Socrnameorg,Status,Vidorg,Category,Risc,Mode")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index1");
            }
            return View(organization);
        }

      
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }
        
        public ActionResult Delete1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organization = db.Organizations.Find(id);
            db.Organizations.Remove(organization);
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

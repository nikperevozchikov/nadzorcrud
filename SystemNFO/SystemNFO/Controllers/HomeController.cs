using OfficeOpenXml.Core.ExcelPackage;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemNFO.Models;
using OfficeOpenXml;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace SystemNFO.Controllers
{
    public class HomeController : Controller
    {  private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Import()
        {
           SqlConnection Con = new SqlConnection();
            string Path = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Con.ConnectionString = Path;
            DataTable DtNew = new DataTable();
            SqlDataAdapter Adp = new SqlDataAdapter("select * from Organizations",Con);
            Adp.Fill(DtNew);
            if (DtNew.Rows.Count > 0) {
                string filepath = Server.MapPath("~/Content/ExcelExportfile.xlsx");

                FileInfo Files = new FileInfo(filepath);
                OfficeOpenXml.ExcelPackage excel = new OfficeOpenXml.ExcelPackage(Files);
              var sheetcreate=  excel.Workbook.Worksheets.Add("OrganizationD");
                for(int i = 0; i<DtNew.Columns.Count; i++)
                {
                    sheetcreate.Cells[1, i + 1].Value = DtNew.Columns[i].ColumnName.ToString();
                }
                for(int i = 0; i < DtNew.Rows.Count; i++)
                {
                    for (int j = 0; j < DtNew.Columns.Count; j++)
                    {
                        sheetcreate.Cells[i + 2, j + 1].Value = DtNew.Rows[i][j].ToString();
                    }
                      
                }
                excel.Save();
            }
            return View();

        }
        public ActionResult Import1()
        {
            SqlConnection Con = new SqlConnection();
            string Path = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Con.ConnectionString = Path;
            DataTable DtNew = new DataTable();
            SqlDataAdapter Adp = new SqlDataAdapter("select * from OrganizationCurators", Con);
            Adp.Fill(DtNew);
            if (DtNew.Rows.Count > 0)
            {
                string filepath = Server.MapPath("~/Content/ExcelExportfile1.xlsx");

                FileInfo Files = new FileInfo(filepath);
                OfficeOpenXml.ExcelPackage excel = new OfficeOpenXml.ExcelPackage(Files);
                var sheetcreate = excel.Workbook.Worksheets.Add("OrganizationCuratorDat");
                for (int i = 0; i < DtNew.Columns.Count; i++)
                {
                    sheetcreate.Cells[1, i + 1].Value = DtNew.Columns[i].ColumnName.ToString();
                }
                for (int i = 0; i < DtNew.Rows.Count; i++)
                {
                    for (int j = 0; j < DtNew.Columns.Count; j++)
                    {
                        sheetcreate.Cells[i + 2, j + 1].Value = DtNew.Rows[i][j].ToString();
                    }

                }
                excel.Save();
            }
            return View();

        }
        public ActionResult Index()
        { return View(); }

            public JsonResult getOrganizations()
        {
            List<Organization> organizations = new List<Organization>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                organizations = db.Organizations.OrderBy(a => a.Vidorg).ToList();
            }
            return new JsonResult { Data = organizations, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /*public JsonResult getProducts(int categoryID)
        {
            List<Product> products = new List<Product>();
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                products = dc.Products.Where(a => a.CategoryID.Equals(categoryID)).OrderBy(a => a.ProductName).ToList();
            }
            return new JsonResult { Data = products, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }*/

     /*   [HttpPost]
        public JsonResult save(OrderMaster order)
        {
            bool status = false;
            DateTime dateOrg;
            var isValidDate = DateTime.TryParseExact(order.OrderDateString, "mm-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out dateOrg);
            if (isValidDate)
            {
                order.OrderDate = dateOrg;
            }

            var isValidModel = TryUpdateModel(order);
            if (isValidModel)
            {
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    dc.OrderMasters.Add(order);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }*/
        /*public ActionResult GetEm()
           {
               List<ApplicationUser> users = new List<ApplicationUser>();
               using (ApplicationDbContext db = new ApplicationDbContext())
               {
                   users = db.Users.ToList();
               }
               return View(users);
           }
          public ActionResult GetEmployees()
           {
               List<Employee> employees = new List<Employee>();
               using (ApplicationDbContext db = new ApplicationDbContext())
               {
                   employees = db.Employees.ToList();
               }
               return View(employees);
           }*/
        //[Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // GET: Employee/Create
      /* public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new ApplicationUser());
            else
                return View(db.Users.Find(id));
            // return View(new Employee());
        }

        // POST: Employee/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit([Bind(Include = "Id,Email,UserName")] ApplicationUser applicationUser
            )
        {
            if (ModelState.IsValid)
            {
                if (applicationUser.Id == null)
                    db.Users.Add(applicationUser);
                else
                    db.Entry(applicationUser).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }
        public ActionResult Delete(int? id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
     
       }*/
    }
}
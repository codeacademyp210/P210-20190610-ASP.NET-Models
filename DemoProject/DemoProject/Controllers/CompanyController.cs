using DemoProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class CompanyController : Controller
    {

        // GET: Company
        public ActionResult Index()
        {
            //List<Company> companies = new List<Company> {
            //    new Company {
            //        Id = 1,
            //        Name = "Simbrella",
            //        Address = "City Point",
            //        Phone = "0125552200"
            //    },
            //    new Company {
            //        Id = 2,
            //        Name = "Code Academy",
            //        Address = "Nizami",
            //        Phone = "0125552525"
            //    },
            //    new Company {
            //        Id = 3,
            //        Name = "Ipeksu",
            //        Address = "Yasamal",
            //        Phone = "01222211144"
            //    }

            //};

            //ViewBag.companyName = company.Name;
            //ViewData["companyAddress"] = company.Address;

            List<Company> companies;
            using (P210_MVCEntities db = new P210_MVCEntities())
            {
                companies = db.Companies.ToList();
            }

            return View(companies);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Company company)
        {
            using (P210_MVCEntities db = new P210_MVCEntities())
            {
                db.Companies.Add(company);
                //db.Entry(company).Property("Id").IsModified = false;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
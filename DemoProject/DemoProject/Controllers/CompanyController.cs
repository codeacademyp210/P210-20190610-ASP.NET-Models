using DemoProject.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class CompanyController : Controller
    {

        // GET: Company
        public ActionResult Index()
        {

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
            ViewBag.FormTitle = "Create Company";
            ViewBag.FormButton = "Save";
            return View("CompanyForm");
        }


        [HttpPost]
        public ActionResult Create(Company company)
        {
            using (P210_MVCEntities db = new P210_MVCEntities())
            {
                db.Companies.Add(company);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            using (P210_MVCEntities db = new P210_MVCEntities())
            {
                Company company = db.Companies.FirstOrDefault(c => c.Id == id);
                if (company != null)
                {
                    db.Companies.Remove(company);
                    db.SaveChanges();
                }
                else
                {
                    return HttpNotFound();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Company company;
            using (P210_MVCEntities db = new P210_MVCEntities())
            {
                company = db.Companies.FirstOrDefault(c => c.Id == id);
            }

            ViewBag.FormTitle = "Update Company";
            ViewBag.FormButton = "Update";

            return View("CompanyForm", company);
        }


        [HttpPost]
        public ActionResult Edit(Company company)
        {
            using (P210_MVCEntities db = new P210_MVCEntities())
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
            }

            //db.Entry(company).Property("Id").IsModified = false;
            return RedirectToAction("Index");
        }

    }
}
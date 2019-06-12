using DemoProject.Models;
using DemoProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class EmployeeController : Controller
    {
        P210_MVCEntities db = new P210_MVCEntities();

        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employees = db.Employees.ToList();
           
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            EmployeeFormViewModel model = new EmployeeFormViewModel();

            using (P210_MVCEntities db = new P210_MVCEntities())
            {
                model.Companies = db.Companies.ToList();
            }

            model.Action = "Create";
            model.FormTitle = "Create New Employee";
            model.SubmitButton = "Save";

            return View("EmployeeForm", model);
        }


        [HttpPost]
        public ActionResult Create(Employee employee, HttpPostedFileBase Photo)
        {
            if (Photo != null)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                employee.Photo = fileName;
                Photo.SaveAs(Path.Combine(Server.MapPath("~"), "Uploads", fileName));
            }
          

            using (P210_MVCEntities db = new P210_MVCEntities())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeFormViewModel model = new EmployeeFormViewModel();

            using (P210_MVCEntities db = new P210_MVCEntities())
            {
                model.Companies = db.Companies.ToList();
                model.Employee = db.Employees.FirstOrDefault(e => e.Id == id);
            }
            
            model.Action = "Edit";
            model.FormTitle = "Update " + model.Employee.Name + " " + model.Employee.Surname;
            model.SubmitButton = "Update";

            return View("EmployeeForm", model);
        }


        [HttpPost]
        public ActionResult Edit(Employee employee, HttpPostedFileBase Photo)
        {
            if (Photo != null)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                employee.Photo = fileName;
                Photo.SaveAs(Path.Combine(Server.MapPath("~"), "Uploads", fileName));
            }

            using (P210_MVCEntities db = new P210_MVCEntities())
            {
                db.Entry(employee).State = EntityState.Modified;


                //if (employee.Photo == null)
                //{
                //    db.Entry(employee).Property(p => p.Photo).IsModified = false;
                //}

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
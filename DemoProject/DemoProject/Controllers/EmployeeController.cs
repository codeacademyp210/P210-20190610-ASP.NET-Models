using DemoProject.Models;
using DemoProject.ViewModels;
using System.Collections.Generic;
using System.Linq;
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

            return View("EmployeeForm", model);
        }


        [HttpPost]
        public ActionResult Create(Employee employee)
        {
           
            using (P210_MVCEntities db = new P210_MVCEntities())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
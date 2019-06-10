using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("employee/create/{groupName}/{classRoom}/{elan_nov}")]
        public ActionResult Create(string elan_nov, string groupName, string classRoom)
        {
            return Content(groupName + " - " + classRoom + " - " + elan_nov);
            return View();
        }




        //[Route("employee/details/{company}")]
        //public ActionResult Update(string company)
        //{
        //    return Content("Hello from edit action. Company = " + company);
        //}


        //[Route("isci/yenile/{company=CA}")]
        //public ActionResult UpdateEmployee(string company)
        //{
        //    return Content("Hello from UpdateEmployee action. Company = " + company);
        //}


    }
}
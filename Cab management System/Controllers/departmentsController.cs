using Cab_management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cab_management_System.Controllers
{
    public class departmentsController : Controller
    {
        // GET: departments
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add_department_name()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add_department_name(departments c)
        {
            c.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            //departments c = new departments();
            //List<departments> lst = c.ShowAll(); 
            return View(new departments().ShowAll());
        }

        [HttpGet]
        public ActionResult Update(int department_id)
        {
            departments c = new departments();
            c.department_id = department_id;
            departments Search_Customer = c.Search();
            return View(Search_Customer);
        }

        [HttpPost]
        public ActionResult Update(departments c)
        {

            c.Update();

            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Delete(int department_id)
        {
            departments c = new departments();
            c.department_id = department_id;
            c.Delete();
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Details(int department_id)
        {
            departments c = new departments();
            c.department_id = department_id;
            departments Search_Customer = c.Search();

            return View(Search_Customer);

        }
    }
}
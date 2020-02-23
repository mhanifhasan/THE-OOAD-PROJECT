using Cab_management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cab_management_System.Controllers
{
    public class employ_salariesController : Controller
    {
        // GET: employ_salaries
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add_employ_salaries()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add_employ_salaries(employ_salaries c)
        {
            c.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            //employ_salaries c = new employ_salaries();
            //List<employ_salaries> lst = c.ShowAll(); 
            return View(new employ_salaries().ShowAll());
        }

        [HttpGet]
        public ActionResult Update(int employ_id)
        {
            employ_salaries c = new employ_salaries();
            c.employ_id = employ_id;
            employ_salaries Search_Customer = c.Search();
            return View(Search_Customer);
        }

        [HttpPost]
        public ActionResult Update(employ_salaries c)
        {

            c.Update();

            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Delete(int employ_id)
        {
            employ_salaries c = new employ_salaries();
            c.employ_id = employ_id;
            c.Delete();
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Details(int employ_id)
        {
            employ_salaries c = new employ_salaries();
            c.employ_id = employ_id;
            employ_salaries Search_Customer = c.Search();

            return View(Search_Customer);

        }
    }
}
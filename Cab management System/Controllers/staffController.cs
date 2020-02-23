using Cab_management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cab_management_System.Controllers
{
    public class staffController : Controller
    {
        // GET: staff
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add_staff()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add_staff(staff c)
        {
            c.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            //staff c = new staff();
            //List<staff> lst = c.ShowAll(); 
            return View(new staff().ShowAll());
        }

        [HttpGet]
        public ActionResult Update(int staff_id)
        {
            staff c = new staff();
            c.staff_id = staff_id;
            staff Search_Customer = c.Search();
            return View(Search_Customer);
        }

        [HttpPost]
        public ActionResult Update(staff c)
        {

            c.Update();

            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Delete(int staff_id)
        {
            staff c = new staff();
            c.staff_id = staff_id;
            c.Delete();
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Details(int staff_id)
        {
            staff c = new staff();
            c.staff_id = staff_id;
            staff Search_Customer = c.Search();

            return View(Search_Customer);

        }

    }
}
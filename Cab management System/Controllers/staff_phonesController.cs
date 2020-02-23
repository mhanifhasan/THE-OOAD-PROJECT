using Cab_management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cab_management_System.Controllers
{
    public class staff_phones_phonesController : Controller
    {
        // GET: staff_phones_phones
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add_staff_phones()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add_staff_phones(staff_phones c)
        {
            c.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            //staff_phones c = new staff_phones();
            //List<staff_phones> lst = c.ShowAll(); 
            return View(new staff_phones().ShowAll());
        }

        [HttpGet]
        public ActionResult Update(int staff_id)
        {
            staff_phones c = new staff_phones();
            c.staff_id = staff_id;
            staff_phones Search_Customer = c.Search();
            return View(Search_Customer);
        }

        [HttpPost]
        public ActionResult Update(staff_phones c)
        {

            c.Update();

            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Delete(int staff_id)
        {
            staff_phones c = new staff_phones();
            c.staff_id = staff_id;
            c.Delete();
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Details(int staff_id)
        {
            staff_phones c = new staff_phones();
            c.staff_id = staff_id;
            staff_phones Search_Customer = c.Search();

            return View(Search_Customer);

        }
    }
}
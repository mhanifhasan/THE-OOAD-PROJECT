using Cab_management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cab_management_System.Controllers
{
    public class driver_phonesController : Controller
    {
        // GET: driver_phones
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add_driver_phones()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add_driver_phones(driver_phones c)
        {
            c.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            //driver_phones c = new driver_phones();
            //List<driver_phones> lst = c.ShowAll(); 
            return View(new driver_phones().ShowAll());
        }

        [HttpGet]
        public ActionResult Update(int driver_id)
        {
            driver_phones c = new driver_phones();
            c.driver_id = driver_id;
            driver_phones Search_Customer = c.Search();
            return View(Search_Customer);
        }

        [HttpPost]
        public ActionResult Update(driver_phones c)
        {

            c.Update();

            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Delete(int driver_id)
        {
            driver_phones c = new driver_phones();
            c.driver_id = driver_id;
            c.Delete();
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Details(int driver_id)
        {
            driver_phones c = new driver_phones();
            c.driver_id = driver_id;
            driver_phones Search_Customer = c.Search();

            return View(Search_Customer);

        }
    }
}
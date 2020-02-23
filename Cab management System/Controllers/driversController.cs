using Cab_management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cab_management_System.Controllers
{
    public class driversController : Controller
    {
        // GET: drivers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add_drivers()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add_drivers(drivers c)
        {
            c.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            //drivers c = new drivers();
            //List<drivers> lst = c.ShowAll(); 
            return View(new drivers().ShowAll());
        }

        [HttpGet]
        public ActionResult Update(int driver_id)
        {
            drivers c = new drivers();
            c.driver_id = driver_id;
            drivers Search_Customer = c.Search();
            return View(Search_Customer);
        }

        [HttpPost]
        public ActionResult Update(drivers c)
        {

            c.Update();

            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Delete(int driver_id)
        {
            drivers c = new drivers();
            c.driver_id = driver_id;
            c.Delete();
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Details(int driver_id)
        {
            drivers c = new drivers();
            c.driver_id = driver_id;
            drivers Search_Customer = c.Search();

            return View(Search_Customer);

        }
    }
}
using Cab_management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cab_management_System.Controllers
{
    public class ridesController : Controller
    {
        // GET: rides
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add_rides()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add_rides(rides c)
        {
            c.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            //rides c = new rides();
            //List<rides> lst = c.ShowAll(); 
            return View(new rides().ShowAll());
        }

        [HttpGet]
        public ActionResult Update(int ride_id)
        {
            rides c = new rides();
            c.ride_id = ride_id;
            rides Search_Customer = c.Search();
            return View(Search_Customer);
        }

        [HttpPost]
        public ActionResult Update(rides c)
        {

            c.Update();

            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Delete(int ride_id)
        {
            rides c = new rides();
            c.ride_id = ride_id;
            c.Delete();
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Details(int ride_id)
        {
            rides c = new rides();
            c.ride_id = ride_id;
            rides Search_Customer = c.Search();

            return View(Search_Customer);

        }
    }
}
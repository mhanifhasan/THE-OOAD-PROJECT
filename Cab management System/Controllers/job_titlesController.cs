using Cab_management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cab_management_System.Controllers
{
    public class job_titlesController : Controller
    {
        // GET: Book
        [HttpGet]


        public ActionResult Add_job_titles()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add_job_titles(job_titles c)
        {
            c.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            //job_titles c = new job_titles();
            //List<job_titles> lst = c.ShowAll(); 
            return View(new job_titles().ShowAll());
        }

        [HttpGet]
        public ActionResult Update(int job_id)
        {
            job_titles c = new job_titles();
            c.job_id = job_id;
            job_titles Search_Customer = c.Search();
            return View(Search_Customer);
        }

        [HttpPost]
        public ActionResult Update(job_titles c)
        {

            c.Update();

            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Delete(int job_id)
        {
            job_titles c = new job_titles();
            c.job_id = job_id;
            c.Delete();
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Details(int job_id)
        {
            job_titles c = new job_titles();
            c.job_id = job_id;
            job_titles Search_Customer = c.Search();

            return View(Search_Customer);

        }
    }
}
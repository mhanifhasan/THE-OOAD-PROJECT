using Cab_management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cab_management_System.Controllers
{
    public class usersController : Controller
    {
        // GET: users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add_users()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add_users(users c)
        {
            c.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            //users c = new users();
            //List<users> lst = c.ShowAll(); 
            return View(new users().ShowAll());
        }

        [HttpGet]
        public ActionResult Update(int c_user_id)
        {
            users c = new users();
            c.c_user_id = c_user_id;
            users Search_Customer = c.Search();
            return View(Search_Customer);
        }

        [HttpPost]
        public ActionResult Update(users c)
        {

            c.Update();

            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Delete(int c_user_id)
        {
            users c = new users();
            c.c_user_id = c_user_id;
            c.Delete();
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Details(int c_user_id)
        {
            users c = new users();
            c.c_user_id = c_user_id;
            users Search_Customer = c.Search();

            return View(Search_Customer);

        }
    }
}
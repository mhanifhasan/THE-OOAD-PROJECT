using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hms2.Controllers
{
    public class HomeController : Controller
        
    {

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }
    [HttpPost]
    public ActionResult Index(string userName, string password)
    {

        if (userName == "farwa" && password == "123")
        {
            Session["IsLogedIn"] = true;
            ViewBag.message = " ";
            return RedirectToAction("Viewrecord", "Home");

        }
        else if (userName == "admin" && password == "321")
        {
            Session["IsLogedIn"] = true;
            ViewBag.message = " ";
            return RedirectToAction("Viewrecord", "Home");

        }
        else
        {
            ViewBag.message = "Password or username is incorrect";
            return View();
        }


    }

    public ActionResult Viewrecord()
    {
        return View();
    }


    public ActionResult logOut()
    {
        Session.Clear();
        return RedirectToAction("Index", "Home"); ;
    }

}
}


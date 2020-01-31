using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hms2.Models;
using hms2.Manager;

namespace hms2.Controllers
{
    [filter.AuthorizeUser]
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult addpatient()
        {
            ViewBag.Message = " ";
            return View();
        }
        Manager.patientmanager pt = new Manager.patientmanager();

        [HttpPost]

        public ActionResult addpatient(AddpatientModel ptnt)
        {
            //ModelState.IsValid
            if (ModelState.IsValid)
            {
                int x = pt.addpatient(ptnt);
                if (x > 0)
                {
                    ViewBag.Message = "Successfully Added";
                }
                else
                {
                    ViewBag.Message = "Unknown Error";
                }
            }
            else
            {
                ViewBag.Message = "Unknown Error";
            }

            return View();

        }

        public ActionResult viewpatient()
        {
            patientmanager pt = new patientmanager();
            List<AddpatientModel> cst = pt.readstudents();


            return View(cst);
        }
        [HttpGet]
        public ActionResult updatepatient(int pID)
        {
            patientmanager pt = new patientmanager();
            AddpatientModel pat = pt.Getupdatepat(pID);
            if (pat == null)
            {
                ViewBag.Message = "data not found";
                return RedirectToAction("pat");
            }
            else
            {
                return View(pat);
            }
        }
        [HttpPost]
        public ActionResult updatepatient(AddpatientModel std)
        {
            if (ModelState.IsValid)
            {
                bool check = pt.updatepat(std);
                if (check)
                {
                    ViewBag.Message = "data update successfully";
                    return RedirectToAction("viewpatient");

                }
            
            else
            {
                return View();


            }
        }
        else 
        {
            return View();
        }
    }
        public ActionResult Deletepatient(int pID)
        {
            bool check = pt.DeleteStd(pID);
            if (check)
            {
                ViewBag.Message = "data delete success";

            }
            else
            {
                ViewBag.Message = "error";
            }

            return RedirectToAction("viewpatient");
        }
    }
}
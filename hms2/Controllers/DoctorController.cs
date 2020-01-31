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
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult adddoctor()
        {
            ViewBag.Message = " ";
            return View();
        }
        Manager.doctormanager dt = new Manager.doctormanager();

        [HttpPost]

        public ActionResult adddoctor(Adddoctormodel dr)
        {
            //ModelState.IsValid
            if (ModelState.IsValid)
            {
                int x = dt.adddoctor(dr);
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
        public ActionResult viewdoctor()
        {
            doctormanager dt = new doctormanager();
            List<Adddoctormodel> adm = dt.readstudents();
            return View(adm);
        }
        [HttpGet]

        public ActionResult updatedoctor(int SID)
        {
            doctormanager dt = new doctormanager();
            Adddoctormodel doc = dt.Getupdatedoc(SID);
            if (doc == null)
            {
                ViewBag.Message = "data not found";
                return RedirectToAction("doc");

            }
            else
            {
                return View(doc);
            }
        }
        [HttpPost]
        public ActionResult updatedoctor(Adddoctormodel std)
        {
            if (ModelState.IsValid)
            {
                bool check = dt.updatedoc(std);
                if (check)
                {
                    ViewBag.Message = "data update successfully";
                    return RedirectToAction("viewdoctor");

                }
                else
                {
                    return View();

                }
            }
            return View();
        }
    

    public ActionResult Deletedoctor(int SID)
        {
            bool check = dt.Deletedctr(SID);
            if (check)
            {
                ViewBag.Message = "data delete success";

            }
            else
            {
                ViewBag.Message = "error";
            }
            return RedirectToAction("viewdoctor");
        }
    }

    }

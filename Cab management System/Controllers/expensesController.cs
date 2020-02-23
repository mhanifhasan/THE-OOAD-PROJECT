using Cab_management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cab_management_System.Controllers
{
    public class expensesController : Controller
    {
        // GET: expenses
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add_expenses()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add_expenses(expenses c)
        {
            c.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {
            //expenses c = new expenses();
            //List<expenses> lst = c.ShowAll(); 
            return View(new expenses().ShowAll());
        }

        [HttpGet]
        public ActionResult Update(int expense_id)
        {
            expenses c = new expenses();
            c.expense_id = expense_id;
            expenses Search_Customer = c.Search();
            return View(Search_Customer);
        }

        [HttpPost]
        public ActionResult Update(expenses c)
        {

            c.Update();

            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Delete(int expense_id)
        {
            expenses c = new expenses();
            c.expense_id = expense_id;
            c.Delete();
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Details(int expense_id)
        {
            expenses c = new expenses();
            c.expense_id = expense_id;
            expenses Search_Customer = c.Search();

            return View(Search_Customer);

        }
    }
}
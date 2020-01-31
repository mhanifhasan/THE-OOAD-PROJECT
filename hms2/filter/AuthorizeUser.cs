using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hms2.filter
{

    public class AuthorizeUser : System.Web.Mvc.ActionFilterAttribute, System.Web.Mvc.IActionFilter
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (HttpContext.Current.Session["IsLogedIn"] == null)
            {

                filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"Controller", "Home" },
                    {"Action", "Index" }

                });

            }

            base.OnActionExecuting(filterContext);
        }

    }
}


using NHAXE.Areas.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NHAXE.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (UserLogin) Session[ CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new 
                    RouteValueDictionary(new { controller = "ADLogin", action = "Index", Areas = "Admin" }));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}
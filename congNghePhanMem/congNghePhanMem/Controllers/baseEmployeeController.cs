using congNghePhanMem.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace congNghePhanMem.Controllers
{
    public class baseEmployeeController : Controller
    {
        // GET: baseEmployee
        protected override void OnActionExecuting(ActionExecutingContext filerContext)
        {
            var sess = (userLogin)Session[commonConst.user_session];
            if (sess == null)
            {
                filerContext.Result = new RedirectToRouteResult
                    (new RouteValueDictionary(new { controller = "loginEmployee", action = "Index"}));
            }
            base.OnActionExecuting(filerContext);
        }
    }
}
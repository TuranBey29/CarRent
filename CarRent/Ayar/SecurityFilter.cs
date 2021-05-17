using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRent.Ayar
{
    public class SecurityFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controlAdi = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            if (controlAdi == "Home")
            {
                base.OnActionExecuting(filterContext);
            }
            else if (HttpContext.Current.Session["Yonetici"] == null && controlAdi != "Login" )
            {
                filterContext.Result = new RedirectResult("/Login/Index");
            }


            base.OnActionExecuting(filterContext);
        }
    }
}
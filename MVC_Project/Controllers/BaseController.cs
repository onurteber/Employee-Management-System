using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Project.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            var Islogin = false;
            if (requestContext.HttpContext.Session["Kullanici"] == null)
            { //Admin Girişi Olmamışsa
                requestContext.HttpContext.Response.Redirect("/Security/Login");
            }
            else
            {
                base.Initialize(requestContext);//Admin içerdeyse sayfa çalışır.
            }
        }
    }
}
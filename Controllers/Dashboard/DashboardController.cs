using MyApp.Filters;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Controllers.Dashboard
{
    [UserAuthenticationFilter]
    public class DashboardController : Controller
    {
        public ActionResult Dashboard()
        {
            return View();
        }

        public JsonResult GetDashboard()
        {
            List<DashboardModel> list = new List<DashboardModel>();
            list = DBModel.Dashboard();
            return Json(list);
        }
    }
}
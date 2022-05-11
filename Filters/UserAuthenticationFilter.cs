using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MyApp.Filters
{
    public class UserAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserId"])))
            {
                HttpCookie reqCookies = filterContext.HttpContext.Request.Cookies["UserCookies"];
                if (reqCookies == null)
                {
                    filterContext.Result = new RedirectResult("~/Home/Index");
                }
                else
                {
                    filterContext.HttpContext.Session["UserId"] = reqCookies["UserId"].ToString();
                    filterContext.HttpContext.Session["Username"] = reqCookies["Username"].ToString();
                    filterContext.HttpContext.Session["Password"] = reqCookies["Password"].ToString();
                }
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }
        }
    }
}
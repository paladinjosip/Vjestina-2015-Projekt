using JJTube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace JJTube.Controllers
{
    public class PrivateController : Controller
    {

        JJTubeDbContext context = new JJTubeDbContext();
        //
        // GET: /Private/
        [Authorize]
        public ActionResult Index()
        {
       //     HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
       //     FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
       //   string userID = ticket.UserData;
       //     //  bool isLoggedIn = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
       //   //  if (User.Identity.IsAuthenticated) return RedirectToAction("Login", "Account");
       //     //  if (!isLoggedIn) return RedirectToAction("Login", "Account");
       //   string cookiePath = ticket.CookiePath;
       //   DateTime expiration = ticket.Expiration;
       //   bool expired = ticket.Expired;
       //   bool isPersistent = ticket.IsPersistent;
       //   DateTime issueDate = ticket.IssueDate;
       //   string name = ticket.Name;
       //   string userData = ticket.UserData;
            string encryptedCookie = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(encryptedCookie);
            return View((object)("=>" + ticket.UserData));
        }

        public ActionResult MyLists()
        {
            return View();
        }
	}
}
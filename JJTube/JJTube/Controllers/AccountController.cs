using JJTube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JJTube.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginUser)
        {
            if (ModelState.IsValid) { 
                //Odradi povezivanje sa bazom, ako user postoji => cookie + redirect na myLists

            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel registerUser)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
	}
}
using JJTube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JJTube.Controllers
{
    public class AccountController : Controller
    {
        JJTubeDbContext context = new JJTubeDbContext();
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

                var sha1 = new SHA1CryptoServiceProvider();
                var password = sha1.ComputeHash(Encoding.Unicode.GetBytes(loginUser.Password));

                People user = context.People.FirstOrDefault(x => (x.Username == loginUser.Username && x.Password.Equals(password)));
                if (user != null) { 
                    //Uspjesan login
                    return RedirectToAction("Index", "Private");

                }
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
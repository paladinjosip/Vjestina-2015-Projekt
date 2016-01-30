using JJTube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JJTube.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
      // public ActionResult Index()
      // {
      //     return View();
      // }
        JJTubeDbContext context = new JJTubeDbContext();
       

    public ActionResult Index()
    {
        List<People> people = context.People.ToList();
        return View(people);
    }

    public ActionResult Details(int id)
    {
        People user = context.People.SingleOrDefault(b => b.UserID == id);
            
        if (user == null)
        {
            return HttpNotFound();
        }
        return View(user);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(People user)
    {
        if (ModelState.IsValid)
        {
            context.People.Add(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(user);
    }

    public ActionResult Edit(int id)
    {
        People book = context.People.Single(p => p.UserID == id);
        if (book == null)
        {
            return HttpNotFound();
        }
        return View(book);
    }

    [HttpPost]
    public ActionResult Edit(int id, People user)
    {
        People _user = context.People.Single(p => p.UserID == id);

        if (ModelState.IsValid)
        {
            _user.Username = user.Username;
            _user.Password = user.Password;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(user);
    }

    public ActionResult Delete(int id)
    {
        People user = context.People.Single(p => p.UserID == id);
        if (user == null)
        {
            return HttpNotFound();
        }
        return View(user);
    }

    [HttpPost]
    public ActionResult Delete(int id, People user)
    {
        People _user = context.People.Single(p => p.UserID == id);
        context.People.Remove(_user);
        context.SaveChanges();
        return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
        context.Dispose();
        base.Dispose(disposing);
    }
}
	}

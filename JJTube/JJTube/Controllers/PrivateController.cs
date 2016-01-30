using JJTube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JJTube.Controllers
{
    [Authorize]
    public class PrivateController : Controller
    {
        private static int UserID;
        private static int ListID;
        JJTubeDbContext context = new JJTubeDbContext();
        //
        // GET: /Private/
        
        public ActionResult Index()
        {
            //Find userID from cookie
            string encryptedCookie = Request.Cookies[FormsAuthentication.FormsCookieName].Value;
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(encryptedCookie);
            UserID = Int32.Parse(ticket.UserData);
            //Find users lists
            IEnumerable<List> myLists = new List<List>();            
            myLists = context.Lists.Where(x => x.User.UserID == UserID).ToList<List>();

           
            //Send lists to view
            return View((object)myLists);
        }

        public ActionResult MyLists()
        {
            return View();
        }

        public ActionResult EditList(int id = 0) //Default vrijednost je 0 => nova lista
        {
            System.Diagnostics.Debug.WriteLine(id);
            if (id == 0){// Edit se pretvara u novu listu ako nismo zadali ID
              
                return View("NewList",new Item_List_ViewModel());
            }; 

            //provjeri je li ta lista pripada tom useru hue hue 
            List list = context.Lists.First(x => x.ListID == id);
            if (!(list.User.UserID == UserID)) { 
                //Vrati odjebi debilu
            }

            //daj mi sve iteme te liste
            //prosljedi iteme view-u
            //prosljedi naziv liste
            System.Diagnostics.Debug.WriteLine(id);
            ListID = list.ListID;
            return View((object)list);
        }

        [HttpPost]
        public JsonResult EditList(List list) { 
            //odredi je li novi ili edit
            //svakako spremi u bazu
            //to je to
            System.Diagnostics.Debug.WriteLine("ajmoo "+ list);
            List edited = context.Lists.FirstOrDefault(x => x.ListID == ListID);
            edited.ListName = list.ListName;
            context.SaveChanges();
            return Json("");
        
        }
        [HttpPost]
        public JsonResult DeleteItem(int id = 0)
        { 
            //Provjeri moze li ovaj korisnik izbrisat taj item!!!!!!!!!!!!!!!
            //Delete item with the id = id lol
            var item = context.Items.FirstOrDefault(m => m.ItemID == id);
            context.Items.Remove(item);
            context.SaveChanges();
            return Json("");
        }
        public JsonResult CreateList(List list) {
            if (ModelState.IsValid) {
                //Kreiranu listu spremi useru!
                People user = context.People.FirstOrDefault(x => x.UserID == UserID);               
                list.User = user;
                context.Lists.Add(list);
                context.SaveChanges();

                return Json("super");
            }

            return Json("Provide List Name");
        }

        
        public ActionResult EditItem(int id = 0)
        {
            if (id == 0) {
               
                return PartialView("EditItem", new Item());
            }

            
           return PartialView("EditItem", context.Items.FirstOrDefault(x => x.ItemID == id));          

        }
        [HttpPost]
        public JsonResult EditItem(Item item)
        {

            Item edited = context.Items.FirstOrDefault(x => x.ItemID == item.ItemID);
        
            //Ako postoji
            if (edited != null)
            {
                edited.ItemName = item.ItemName;
                edited.ItemLink = item.ItemLink;
                context.SaveChanges();
            }//Ako ne postoji
            else {
                edited = new Item();
                edited.ItemName = item.ItemName;
                edited.ItemLink = item.ItemLink;
                edited.List = context.Lists.FirstOrDefault(x => x.ListID == ListID);
                context.Items.Add(edited);
                context.SaveChanges();
            
            }
           
            //Udri update u bazi ako je stari
            //Uvali u bazu ako je novi
            //Nekom magijom saznaj o kojoj listi se radi
            System.Diagnostics.Debug.WriteLine(item);
            
            return Json("");

        }

        [HttpPost]
        public JsonResult DeleteList(int ListID) {
            
            context.Items.RemoveRange(context.Items.Where(x => x.List == context.Lists.FirstOrDefault(y => y.ListID == ListID)));
            context.Lists.Remove(context.Lists.FirstOrDefault(x => x.ListID == ListID));
            context.SaveChanges();
            return Json(Url.Action("Index", "Private"));
        }
       
        public ActionResult Playlist(int id) {
           
            //provjeri je li ta lista pripada tom useru hue hue 
            List list = context.Lists.FirstOrDefault(x => x.ListID == id);
            if (!(list.User.UserID == UserID))
            {
                //Vrati odjebi debilu
            }
            return View("Playlist", list);
        }
	}
}
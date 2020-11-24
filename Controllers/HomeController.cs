using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using JJAutos.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JJAutos.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;
        private readonly JJAutosDBEntities1 JJAutosDB = new JJAutosDBEntities1();

        public HomeController()
        {
                
        }
        public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, JJAutosDBEntities1 jjsDB)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this.JJAutosDB = jjsDB;
        }
  
        [HttpGet]  
        public ActionResult Index()
        { 
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]  
        public ActionResult ViewProfile() {
            var MyProfile = new ProfileViewModel();
            MyProfile.MyCars = ProfileViewModel.ToViewModel(JJAutosDB.CarDBs.Where(m => (m.UserId) == User.Identity.Name).ToList());

            return View(MyProfile);
        }   
        
        [HttpPost]
        public ActionResult ViewProfile(ProfileViewModel MyProfile) {
            MyProfile.MyCars = ProfileViewModel.ToViewModel(JJAutosDB.CarDBs.Where(m => (m.UserId) == User.Identity.Name).ToList());
           
            return View(MyProfile);
        }

        [HttpGet]
        public ActionResult AddCar(){

            return View();
       }

        [HttpPost]
        public ActionResult AddCar(CarViewModel newCar, HttpPostedFileBase file)
        {
            string fn = "" ;

            if (file != null & file.ContentLength > 0)
            {

                string filename = Path.GetFileName(file.FileName);
                filename = DateTime.Now.ToString("yymmssfff") + filename;
                string imagePath = Path.Combine(Server.MapPath("~/Static/"), filename);
                file.SaveAs(imagePath);
                fn = imagePath;

            }
            Guid g = Guid.NewGuid();

            var newCarDB = new CarDB()
            {
                CarId = g.ToString(),
                UserId = User.Identity.Name,
                Make = newCar.Make,
                Model = newCar.Model,
                Colour = newCar.Colour,
                RegNo = newCar.RegNo,
                PicturePath = fn,

            };

            JJAutosDB.CarDBs.Add(newCarDB);
            JJAutosDB.SaveChanges();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult MyHistory() {
            var MyCars = JJAutosDB.CarDBs.Where(c => c.UserId == User.Identity.Name).ToList();
                MyHistoryViewModel myHistory = new MyHistoryViewModel();
            foreach (var car in MyCars) {
               var qoutes = (JJAutosDB.QouteDBs.Where(q => q.CarId == car.RegNo).ToList());
                myHistory.MyQoutes.AddRange(QouteViewModel.ToQouteViewModel(qoutes));
            }
                    return View(myHistory);
        }

        [HttpPost]
        public ActionResult MyHistory(MyHistoryViewModel myHistory) {

            return View();
        }
 
        public ActionResult Delete(string id)
        {
            var qoute = JJAutosDB.QouteDBs.Where(q => q.QouteId == id).FirstOrDefault();
            JJAutosDB.QouteDBs.Remove(qoute);
            JJAutosDB.SaveChanges();
            return RedirectToAction("MyHistory");
        }
    }
}
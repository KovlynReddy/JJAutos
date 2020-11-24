using JJAutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JJAutos.Controllers
{
    [Authorize]
    public class RepairController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly JJAutosDBEntities1 JJAutosDB = new JJAutosDBEntities1();

        public RepairController()
        {

        }
        public RepairController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, JJAutosDBEntities1 jjsDB)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            JJAutosDB = jjsDB;
        }
        // GET: Repair
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateQoute() {
            var newQoute = new QouteViewModel();
            newQoute.CarIds = JJAutosDB.CarDBs.Where(c => c.UserId == User.Identity.Name).Select(m => m.RegNo).ToList();
            return View(newQoute);
        }      
        
        [HttpPost]
        public ActionResult CreateQoute(QouteViewModel newQoute) {
            Guid g = Guid.NewGuid();
            var car = CarViewModel.ToViewModel(JJAutosDB.CarDBs.Where(c => c.RegNo == newQoute.CarId).FirstOrDefault());
            newQoute.CalculateTotal(car.GetModelMultiplier(),car.GetMakeMultiplier());
            QouteDB qoute = new QouteDB()
            {

                CarId = newQoute.CarId,
                QouteId = g.ToString(),
                DateBooking = newQoute.DateBooking,
                IsDone = (newQoute.IsDone == 1 ) ? 1 : 0 ,
                TotalUpper = newQoute.TotalUpper,
                TotalLower = newQoute.TotalLower,
                Maintanance = newQoute.Maintance ? 1 : 0,
                RepairCheckup = newQoute.RepairCheckUp ? 1 : 0,
                TyreChange = newQoute.TyreChange ? 1 : 0,
                ClutchCheckup = newQoute.ClutchCheckup ? 1 : 0,
                EngineCheckup = newQoute.EngineCheckup ? 1 : 0,
                BreakCheckup = newQoute.BreakCheckup ? 1 : 0,
                SuspensionCheckup = newQoute.SuspensionCheckup ? 1 : 0,
                FullFluidChange = newQoute.FullFluidChange ? 1 : 0,
                Notes = newQoute.CarId,

            };

            JJAutosDB.QouteDBs.Add(qoute);
            JJAutosDB.SaveChanges();

            return RedirectToAction("QouteConfirmation", "Repair",qoute);
        }

        [HttpGet]
        public ActionResult QouteConfirmation(QouteDB newQoute) {
            
            //JJAutosDB.QouteDBs.Add(newQoute);
            //JJAutosDB.SaveChanges();

            return View(newQoute);
        }

        public ActionResult Confirm()
        {
            return RedirectToAction("MyHistory", "Home");
        }   

 
        public ActionResult Deny(string id)
        {

            var qoute = JJAutosDB.QouteDBs.Where(q => q.QouteId == id).FirstOrDefault();
            JJAutosDB.QouteDBs.Remove(qoute);
            JJAutosDB.SaveChanges();

            return RedirectToAction("MyHistory", "Home");
        }

    }
}
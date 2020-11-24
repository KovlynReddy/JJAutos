using JJAutos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JJAutos.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;
        private readonly JJAutosDBEntities1 JJAutosDB = new JJAutosDBEntities1();

        // GET: Admin
        public ActionResult Index(AdminMainViewModel mvm)
        {
            ViewBag.bg = "~/Static/car-drive-street-road-over-city-skyscraper-view-cityscape-background-J7357D.jpg";
            mvm.PendingBookings = QouteViewModel.ToQouteViewModel(JJAutosDB.QouteDBs.Where(q => q.IsDone == 1 ).ToList());
            mvm.HistoryBookings = QouteViewModel.ToQouteViewModel(JJAutosDB.QouteDBs.Where(q => q.IsDone == 0 ).ToList());
            mvm.TodaysBookings = QouteViewModel.ToQouteViewModel(JJAutosDB.QouteDBs.Where(q => q.DateBooking == DateTime.Today ).ToList());
            mvm.UnapprovedBookings = QouteViewModel.ToQouteViewModel(JJAutosDB.QouteDBs.Where(q => q.IsDone == 0 ).ToList());
           
            return View(mvm);
        }
        public ActionResult ViewPendingQoutes() {

            return View();
        }

        public ActionResult ViewHistoryQoutes() {

            return View();
        }

        public ActionResult Approve(string id) {

            var qoute = JJAutosDB.QouteDBs.Where(q => q.QouteId == id).FirstOrDefault();
            qoute.IsDone = 1;

            JJAutosDB.QouteDBs.Attach(qoute);
            JJAutosDB.Entry(qoute).State = EntityState.Modified;

            JJAutosDB.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id) {
            var qoute = JJAutosDB.QouteDBs.Where(q => q.QouteId == id).FirstOrDefault();
            JJAutosDB.QouteDBs.Remove(qoute);
            JJAutosDB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
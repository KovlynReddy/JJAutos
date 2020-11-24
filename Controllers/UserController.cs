using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JJAutos.Models;
using Microsoft.AspNet.Identity;

namespace JJAutos.Controllers
{
    public class UserController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly JJAutosDBEntities1 JJAutosDB;

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, JJAutosDBEntities1 jjsDB)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            JJAutosDB = jjsDB;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(string id) {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Account account) {

            return View();
        }

    }
}
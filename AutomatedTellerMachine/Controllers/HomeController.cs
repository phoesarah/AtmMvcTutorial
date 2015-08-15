using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AutomatedTellerMachine.Models;

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccountID = db.CheckingAccounts.Where(x => x.ApplicationUserID == userId).First().Id;
            ViewBag.CheckingAccountId = checkingAccountID;
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles ="Admin")]
        [Authorize] //this attribute (filter) without paramaters allows only people logged in no matter what role
        //can also put this on a controller class and then [AllowAnonymous] for the ones you don't want authorized.
         
        [HttpPost]
        public ActionResult Contact(string message)
        {
            //todo do something with message
            ViewBag.Message = "Ywe got your message.";

            return View();
        }

        public ActionResult  Serial(string letterCase)
        {
            var serial = "ASPNETMVC5ATM1";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            return Content(serial);
            // return Json(new { name = "serial", value = serial }, JsonRequestBehavior.AllowGet );
            // return RedirectToAction("About");
        }
    }
}
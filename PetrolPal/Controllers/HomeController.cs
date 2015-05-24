using PetrolPal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetrolPal.Controllers
{
    public class HomeController : Controller
    {
        public DataService ds = new DataService();
        public string regnumber { get; set; }
        
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Your application home page."

            if (regnumber != null)
            {
                return RedirectToAction("TripTable");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Index(IndexViewModel model)
        {
            ViewBag.Message = "Your application home page."

            regnumber = model.regnum;
            ds.regnumber = regnumber;
            return RedirectToAction("TripTable");
        }

        public ActionResult TripTable()
        {
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
    }
}
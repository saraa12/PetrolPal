using Newtonsoft.Json.Linq;
using PetrolPal.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetrolPal.Controllers
{
    public class HomeController : Controller
    {
        public DataService ds = new DataService();
        //public string regnumber { get; set; }
        //DEBUGGING PURPOSES SECTION:
        public string regnumber = "OT380";
        //END DEBUGGING PURPOSES SECTION
        
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Your application home page.";

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
            ViewBag.Message = "Your application home page.";

            regnumber = model.regnum;
            ds.regnumber = regnumber;
            return RedirectToAction("TripTable");
        }

        [HttpGet]
        public ActionResult TripTable()
        {
            if (regnumber != null)
            {
                TripTableViewModel model = new TripTableViewModel();
                TimeSpan t = new TimeSpan(168, 00, 00);
                DateTime defaultTimeTo = DateTime.Now;
                DateTime defaultTimeFrom = DateTime.Now.Subtract(t);

                model.trips = new List<Trip>();
                model.averageCost = 0.0;
                model.averageFuel = 0.0;
                model.totalCost = 0.0;
                model.totalFuel = 0.0;
                model.timeTo = defaultTimeTo.ToString("yyyy-MM-dd HH:mm");
                model.timeFrom = defaultTimeFrom.ToString("yyyy-MM-dd HH:mm");

                // Lets assume fuel cost is 230.1 kr / liter, random stuff
                model.fuelCost = 230.1;

                ds.regnumber = regnumber;
                var tripsString = ds.getTripsData(model.timeFrom, model.timeTo);
                JArray trips = JArray.Parse(tripsString);
                Trip trip = new Trip();
                foreach (var obj in trips)
                {
                    dynamic data = JObject.Parse(obj.ToString());
                    trip.fuelUsed = data.Fuel;
                    trip.startTime = data.StartTime;
                    trip.endTime = data.EndTime;

                    model.totalFuel = model.totalFuel + trip.fuelUsed;
                    model.totalCost = model.totalCost + (trip.fuelUsed * model.fuelCost);

                    model.trips.Add(trip);
                }

                model.averageFuel = model.totalFuel / model.trips.Count();
                model.averageCost = model.totalCost / model.trips.Count();

                return View(model);
            } 
            else
            {
                return RedirectToAction("Index");
            }
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
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
        public static DataService ds = null;
        
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "Your application home page.";

            if (ds != null)
            {
                return RedirectToAction("TripTable");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Index(string regnum)
        {
            ViewBag.Message = "Your application home page.";

            ds = new DataService(regnum);
            return RedirectToAction("TripTable");
        }

        [HttpGet]
        public ActionResult TripTable()
        {
            if (ds != null)
            {
                TimeSpan t = new TimeSpan(168, 00, 00);
                DateTime defaultTimeTo = DateTime.Now;
                DateTime defaultTimeFrom = DateTime.Now.Subtract(t);
           
                return View(TripHelper(defaultTimeFrom, defaultTimeTo));
            } 
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult TripTable(DateTime timeFrom, DateTime timeTo)
        {
            if (ds != null)
            {
                return View(TripHelper(timeFrom, timeTo));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult VehicleInfo()
        {
            if (ds != null)
            {
                VehicleInfoViewModel model = new VehicleInfoViewModel();
                var infoString = ds.getVehicleInfo();

                dynamic data = JObject.Parse(infoString);
                model.registrationNumber = data.RegNumber;
                model.IMEI = data.IMEI;
                model.VIN = data.VIN;
                model.totalKm = data.Odo;
                model.vehicleType = data.VehicleType;
                model.nextInspection = data.NextInspection;

                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        private TripTableViewModel TripHelper(DateTime startTime, DateTime endTime)
        {
            TripTableViewModel model = new TripTableViewModel();

            model.trips = new List<Trip>();
            model.averageCost = 0.0;
            model.averageFuel = 0.0;
            model.averageKm = 0;
            model.totalCost = 0.0;
            model.totalFuel = 0.0;
            model.totalKm = 0;
            model.timeTo = endTime.ToString("yyyy-MM-dd HH:mm");
            model.timeFrom = startTime.ToString("yyyy-MM-dd HH:mm");

            // Lets assume fuel cost is 230.1 kr / liter, random stuff
            model.fuelCost = 230.1;

            var tripsString = ds.getTripsData(model.timeFrom, model.timeTo);
            JArray trips = JArray.Parse(tripsString);

            foreach (var obj in trips)
            {
                Trip trip = new Trip();
                dynamic data = JObject.Parse(obj.ToString());
                trip.fuelUsed = data.Fuel;
                trip.startTime = data.StartTime;
                trip.endTime = data.EndTime;
                trip.km = data.Km;

                model.totalFuel = model.totalFuel + trip.fuelUsed;
                model.totalCost = model.totalCost + (trip.fuelUsed * model.fuelCost);
                model.totalKm = model.totalKm + trip.km;

                model.trips.Add(trip);
            }

            if (model.trips.Count() != 0)
            {
                model.averageFuel = model.totalFuel / model.trips.Count();
                model.averageCost = model.totalCost / model.trips.Count();
                model.averageKm = model.totalKm / model.trips.Count();
            }

            return model;
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
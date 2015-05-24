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
        public ActionResult Index(string registrationNumber)
        {
            ViewBag.Message = "Your application home page.";

            regnumber = registrationNumber;
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
                model.averageKm = 0;
                model.totalCost = 0.0;
                model.totalFuel = 0.0;
                model.totalKm = 0;
                model.timeTo = defaultTimeTo.ToString("yyyy-MM-dd HH:mm");
                model.timeFrom = defaultTimeFrom.ToString("yyyy-MM-dd HH:mm");

                // Lets assume fuel cost is 230.1 kr / liter, random stuff
                model.fuelCost = 230.1;

                ds.regnumber = regnumber;
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

                model.averageFuel = model.totalFuel / model.trips.Count();
                model.averageCost = model.totalCost / model.trips.Count();
                model.averageKm = model.totalKm / model.trips.Count();

                return View(model);
            } 
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult TripTable(DateTime timeFrom, DateTime timeTo)
        {
            if (regnumber != null)
            {
                TripTableViewModel model = new TripTableViewModel();
                model.trips = new List<Trip>();
                model.averageCost = 0.0;
                model.averageFuel = 0.0;
                model.averageKm = 0;
                model.totalCost = 0.0;
                model.totalFuel = 0.0;
                model.totalKm = 0;
                model.timeTo = timeTo.ToString("yyyy-MM-dd HH:mm");
                model.timeFrom = timeFrom.ToString("yyyy-MM-dd HH:mm");

                // Lets assume fuel cost is 230.1 kr / liter, random stuff
                model.fuelCost = 230.1;

                ds.regnumber = regnumber;
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

                model.averageFuel = model.totalFuel / model.trips.Count();
                model.averageCost = model.totalCost / model.trips.Count();
                model.averageKm = model.totalKm / model.trips.Count();

                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult VehicleInfo()
        {
            VehicleInfoViewModel model = new VehicleInfoViewModel();
            var infoString = ds.getVehicleInfo();

            dynamic data = JObject.Parse(infoString);
            model.registrationNumber = regnumber;
            model.IMEI = data.IMEI;
            model.VIN = data.VIN;
            model.totalKm = data.Odo;
            model.vehicleType = data.VehicleType;
            model.nextInspection = data.NextInspection;

            return View(model);
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
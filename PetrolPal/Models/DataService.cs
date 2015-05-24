using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace PetrolPal.Models
{
    public class DataService
    {
        private string key = "DABwk0Z8IudITSREwZXqQ==";

        string regnumber = null;

        public DataService(string _regnumber)
        {
            regnumber = _regnumber;
        }

        public bool registeredRegNumber()
        {
            if (regnumber != null)
            {
                return true;
            }
            return false;
        }

        public string getRegNumber()
        {
            return regnumber;
        }

        public string getVehicleInfo()
        {
            string requestname = "getvehicleinfo";

            string url = "https://insolica.com/api/" + requestname + "/?regnumber=" + regnumber + "&key=" + key;

            WebClient c = new WebClient();
            var dataObject = c.DownloadString(url);

            return dataObject;
        }

        public string getTripsData(string timeFrom, string timeTo)
        {
            string requestname = "gettripsdata";

            string url = "https://insolica.com/api/" + requestname + "?RegNumber=" + regnumber + "&key=" + key + "&from=" + timeFrom + "&to=" + timeTo;

            WebClient c = new WebClient();
            var dataObject = c.DownloadString(url);

            return dataObject;
        }

        public string getEngineData(string timeFrom, string timeTo)
        {
            string requestname = "getenginedata";

            string url = "https://insolica.com/api/" + requestname + "?RegNumber=" + regnumber + "&key=" + key + "&from=" + timeFrom + "&to=" + timeTo;

            WebClient c = new WebClient();
            var dataObject = c.DownloadString(url);

            return dataObject;
        }
    }
}
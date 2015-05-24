using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetrolPal.Models
{
    public class VehicleInfoViewModel
    {
        public string vehicleType { get; set; }
        public string registrationNumber { get; set; }
        public string IMEI { get; set; }
        public string VIN { get; set; }
        public double totalKm { get; set; }
        public string nextInspection { get; set; }
    }
}
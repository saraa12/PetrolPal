using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetrolPal.Models
{
    public class TripTableViewModel
    {
        public List<Trip> trips { get; set; }
        public string timeFrom { get; set; }
        public string timeTo { get; set; }
        public double totalCost { get; set; }
        public double averageCost { get; set; }
        public double totalFuel { get; set; }
        public double averageFuel { get; set; }
        public double fuelCost { get; set; }
    }
}
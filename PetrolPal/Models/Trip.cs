using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetrolPal.Models
{
    public class Trip
    {
        public double fuelUsed { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
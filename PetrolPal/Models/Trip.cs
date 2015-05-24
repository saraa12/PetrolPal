﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetrolPal.Models
{
    public class Trip
    {
        public double fuelUsed { get; set; }
        //Remember that we need to select time as DateTime then parse to this format of string: yyyy-MM-dd HH:mm
        public string startTime { get; set; }
        public string endTime { get; set; }
    }
}
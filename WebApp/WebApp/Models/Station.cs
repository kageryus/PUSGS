﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Station
    {
        public int Id {get;set;}
        public string Name { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; } //long lat dodati

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    [NotMapped]
    public class Location
    {
        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
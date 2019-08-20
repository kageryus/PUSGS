using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Station
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        
        public double Longitude { get; set; } //long lat dodati

        public double Latitude { get; set; }

        public virtual List<Line> Lines {get;set;}

    }
}
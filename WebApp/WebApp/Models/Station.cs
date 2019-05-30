using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Station
    {
        public Guid Id {get;set;}
        public string Name { get; set; }
        public Guid LocationId { get; set; }
        public Location Location { get; set; } //long lat dodati

        public virtual List<Station> stations { get; set; }
    }
}
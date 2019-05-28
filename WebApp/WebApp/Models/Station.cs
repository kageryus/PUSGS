using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Station
    {
        public Guid ID {get;set;}
        public string Name { get; set; }
        public Location Location { get; set; }
    }
}
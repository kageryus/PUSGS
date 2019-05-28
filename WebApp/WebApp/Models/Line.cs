using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Line
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<Location> coordinates {get;set;}
        
        public Guid Timetable { get; set; }
    }
}
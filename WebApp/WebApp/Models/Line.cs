using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Line
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimetableId { get; set; }
        public Timetable Timetable { get; set; }

        public virtual List<Location> coordinates {get;set;}

        public virtual List<Station> stations { get; set; }
        
    }
}
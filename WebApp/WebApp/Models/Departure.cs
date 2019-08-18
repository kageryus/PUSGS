using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Departure
    {
        public int Id { get; set; }

        public int Hour { get; set; }

        public virtual List<int> Minutes { get; set; }
                
        public int TimeTableId { get; set; }
        public Timetable Timetable { get; set; }
    }
}
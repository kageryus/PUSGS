using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Timetable
    {
        public int Id { get; set; }

        public DayType Day { get; set; }

        public int LineId { get; set; }
        public Line Line { get; set; }

        public virtual List<Departure> Departures { get; set; }
    }
}
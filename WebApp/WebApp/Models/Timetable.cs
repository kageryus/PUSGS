using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Timetable
    {
        public Guid ID { get; set; }
        public string LineName { get; set; }
        //kljuc je sat, vrednost su minuti u string formatu tipa 16,26,36, itd do 59
        public Dictionary<int,string> Time { get; set; }
    }
}
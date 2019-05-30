using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Timetable
    {
        public int Id { get; set; }

        //kljuc je sat, vrednost su minuti u string formatu tipa 16,26,36, itd do 59
        public string WorkDay { get; set; } //Format ce biti 15:13,14,15,16 ; 16:23,46,......

        public string Saturday { get; set; }

        public string Sunday { get; set; }
        //subotu i nedelju 
    }
}
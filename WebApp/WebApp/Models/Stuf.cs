using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Stuf
    {
        public int Id { get; set; }
        public TicketType Type { get; set; }

        public double Price { get; set; }
    }
}
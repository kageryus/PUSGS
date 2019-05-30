using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Stuf
    {
        public Guid Id { get; set; }
        public TicketType Type { get; set; }

        public int Price { get; set; }
    }
}
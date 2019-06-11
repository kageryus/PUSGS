using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public TicketType Type { get; set; }
        public bool IsValid { get; set; }

        public DateTime BuyTime { get; set; }

        public int PassengerId { get; set; }
    }
}
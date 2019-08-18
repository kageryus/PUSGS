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
        public TimeSpan RemainingTime { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public double Price { get; set; }
    }
}
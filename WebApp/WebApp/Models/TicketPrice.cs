using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class TicketPrice
    {
        public int Id { get; set; }
        public TicketType Type { get; set; }

        public CustomerType CustomerType { get; set; }

        //public LineType LineType { get; set; }
        public int PriceListId { get; set; }
        public Pricelist Pricelist { get; set; }
        public double Price { get; set; }
    }
}
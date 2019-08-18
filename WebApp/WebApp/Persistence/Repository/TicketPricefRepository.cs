using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class TicketPricefRepository : Repository<TicketPrice, int>, ITicketPriceRepository
    {
        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }
        public TicketPricefRepository(DbContext context) : base(context)
        {

        }
    }
}
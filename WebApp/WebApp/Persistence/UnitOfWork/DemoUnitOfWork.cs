using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;
using WebApp.Persistence.Repository;

namespace WebApp.Persistence.UnitOfWork
{
    public class DemoUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
      
        [Dependency]
        public IStationRepository Station { get; set; }
        [Dependency]
        public ILineRepository Line { get; set; }
        [Dependency]
        public IDeparturesRepository Departure { get; set; }

        [Dependency]
        public ITimetableRepository Timetable { get; set; }
        [Dependency]
        public IIndexRepository Index { get; set; }
        [Dependency]
        public ILocationRepository Location { get; set; }
        [Dependency]
        public IPricelistRepository Pricelist { get; set; }
        [Dependency]
        public ITicketPriceRepository TicketPrice { get; set; }
        [Dependency]
        public ITicketRepository Ticket { get; set; }
        public DemoUnitOfWork(DbContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
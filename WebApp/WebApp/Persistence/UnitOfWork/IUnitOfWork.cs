using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Persistence.Repository;

namespace WebApp.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IStationRepository Station {get;set;}
        ITimetableRepository Timetable { get; set; }
        ILineRepository Line { get; set; }
        IIndexRepository Index { get; set; }
        ILocationRepository Location { get; set; }
        IPricelistRepository Pricelist { get; set; }
        ITicketPriceRepository TicketPrice { get; set; }
        
        ITicketRepository Ticket { get; set; }
        IDeparturesRepository Departure { get; set; }
        int Complete();
    }
}

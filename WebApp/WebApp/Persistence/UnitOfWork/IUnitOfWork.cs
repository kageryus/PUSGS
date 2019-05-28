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
        int Complete();
    }
}

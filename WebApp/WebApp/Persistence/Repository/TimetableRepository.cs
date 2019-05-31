using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class TimetableRepository : Repository<Timetable,int>, ITimetableRepository
    {
        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }

        public TimetableRepository(DbContext context) : base(context)
        {

        }
    }
}
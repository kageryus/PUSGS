using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class DeparturesRepository : Repository<Departure, int>, IDeparturesRepository
    {
        protected ApplicationDbContext AppDbContext { get { return context as ApplicationDbContext; } }

        public DeparturesRepository(DbContext context) : base(context)
        {

        }
    }
}
using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using WebApp.Models;

namespace WebApp.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Line> Lines { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Timetable> TimeTables { get; set; }

        public DbSet<Index> Index { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Pricelist> Pricelist { get; set; }
        public DbSet<Stuf> Stuf { get; set; }
        public ApplicationDbContext()
            : base("name=BusSqlDataBase", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
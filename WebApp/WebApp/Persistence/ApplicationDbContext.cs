﻿using System;
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

        public DbSet<Index> Indexs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pricelist> Pricelists { get; set; }
        public DbSet<TicketPrice> Stufs { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
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
namespace WebApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Persistence.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApp.Persistence.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Location loc1 = new Location() { Latitude = 45.238761025081644, Longitude = 19.84782636165619 };
            //Location loc2 = new Location() { Latitude = 45.23888435038886, Longitude = 19.847837341949344 };
            //Location loc3 = new Location() { Latitude = 45.23900767542845, Longitude = 19.847880508750677 };
            //Location loc4 = new Location() { Latitude = 45.239148558981874, Longitude = 19.848009757697582 };
            //Location loc5 = new Location() { Latitude = 45.239349879616015, Longitude = 19.847999531775713 };

            //context.Locations.AddOrUpdate(a => a.Id, loc1);
            //context.Locations.AddOrUpdate(a => a.Id, loc2);
            //context.Locations.AddOrUpdate(a => a.Id, loc3);
            //context.Locations.AddOrUpdate(a => a.Id, loc4);
            //context.Locations.AddOrUpdate(a => a.Id, loc5);

            //context.SaveChanges();

            //Timetable timetable1 = new Timetable() { WorkDay = "10:13,15,16,17;11:26,36,47", Saturday = "9:11,22,33,44;10:22,44,55", Sunday = "13:15,45;16:14,16,36" };
            //context.TimeTables.AddOrUpdate(a => a.Id, timetable1);

            //context.SaveChanges();

            //Station station1 = new Station() { LocationId = context.Locations.Find(1).Id, Name = "bajina stanica" };
            //Station station2 = new Station() { LocationId = context.Locations.Find(2).Id, Name = "Ilije Bircanina" };

            //context.Stations.AddOrUpdate(a => a.Id, station1);
            //context.Stations.AddOrUpdate(a => a.Id, station2);

            //context.SaveChanges();

            //Line line = new Line() { Name = "8A", TimetableId = context.TimeTables.Find(1).Id, stations = new List<Station>() { context.Stations.Find(1), context.Stations.Find(2) }, coordinates = new List<Location>() { context.Locations.Find(1), context.Locations.Find(2), context.Locations.Find(3), context.Locations.Find(4), context.Locations.Find(5) } };

            //context.Lines.AddOrUpdate(a => a.Id, line);

            //context.SaveChanges();
            


            //Line OsamA = new Line();
            //OsamA.Name = "8A";
            //OsamA.TimetableId = 1;
            //OsamA.Timetable = timetable1;
            //OsamA.stations.Add(station1);
            //OsamA.stations.Add(station2);

            //OsamA.coordinates.Add(Loc1);
            //OsamA.coordinates.Add(Loc2);
            //OsamA.coordinates.Add(Loc3);
            //OsamA.coordinates.Add(Loc4);
            //OsamA.coordinates.Add(Loc5);

            //context.Lines.Add(OsamA);


            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Controller"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Controller" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "AppUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppUser" };

                manager.Create(role);
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "admin@yahoo.com"))
            {
                var user = new ApplicationUser() { Id = "admin", UserName = "admin@yahoo.com", Email = "admin@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Admin123!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "appu@yahoo.com"))
            { 
                var user = new ApplicationUser() { Id = "appu", UserName = "appu@yahoo.com", Email = "appu@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Appu123!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "AppUser");
            }
        }
    }
}

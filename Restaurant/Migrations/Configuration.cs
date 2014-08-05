namespace Restaurant.Migrations
{
    using Restaurant.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Restaurant.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Restaurant.Models.ApplicationDbContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            db.Restaurants.AddOrUpdate(
              r => r.Id,
              new AddRestaurant { Id = 1, Name = "Gringos", Cuisine = "Mexican", Rating = 5 },
              new AddRestaurant { Id = 2, Name = "Bollywocks", Cuisine = "Mexican", Rating = 5 },
              new AddRestaurant { Id = 3, Name = "Loops", Cuisine = "Mexican", Rating = 5 }
            );

        }
    }
}

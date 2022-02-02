using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class MoviesAppContext : DbContext
    {
        //constructor
        public MoviesAppContext (DbContextOptions<MoviesAppContext> options) : base (options)
        {
            //Leave Blank for Now
        }

        public DbSet<ApplicationInfo> responses { get; set; }
        public DbSet<Category> Categories { get; set; }
        //seed the data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category {CategoryId=1, CategoryName="Drama"},
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Family" }

                );

            mb.Entity<ApplicationInfo>().HasData(

                    new ApplicationInfo
                    {
                        ApplicationId = 1,
                        CategoryId = 1,
                        Title = "La La Land",
                        Year = 2016,
                        Director = "Damien Russell",
                        Rating = "PG-13"

                    },
                    new ApplicationInfo
                    {
                        ApplicationId = 2,
                        CategoryId = 2,
                        Title = "The Wedding Planner",
                        Year = 2001,
                        Director = "Adam Shankman",
                        Rating = "PG-13"

                    },

                    new ApplicationInfo
                    {
                        ApplicationId = 3,
                        CategoryId = 3,
                        Title = "Enchanted",
                        Year = 2007,
                        Director = "Kevin Lima",
                        Rating = "PG"

                    }

                );
        }
    }
}

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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationInfo>().HasData(

                    new ApplicationInfo
                    {
                        ApplicationId = 1,
                        Category = "Comedy",
                        Title = "The Mask",
                        Year = 1994,
                        Director = "Chuck Russell",
                        Rating = "PG-13"

                    },
                    new ApplicationInfo
                    {
                        ApplicationId = 2,
                        Category = "Comedy",
                        Title = "The Wedding Planner",
                        Year = 2001,
                        Director = "Adam Shankman",
                        Rating = "PG-13"

                    },

                    new ApplicationInfo
                    {
                        ApplicationId = 3,
                        Category = "Family",
                        Title = "Enchanted",
                        Year = 2007,
                        Director = "Kevin Lima",
                        Rating = "PG"

                    }

                );
        }
    }
}

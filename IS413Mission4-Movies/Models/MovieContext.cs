using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413Mission5_Movies.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base (options)
        {

        }

        public DbSet<Movie> movies { get; set; }
        public DbSet<Category> categories { get; set; }

        // seeding database
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Action/Adventure"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Drama"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Family"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Horror/Suspense"
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Miscellaneous"
                },
                new Category
                {
                    CategoryId = 7,
                    CategoryName = "Television"
                },
                new Category
                {
                    CategoryId = 8,
                    CategoryName = "VHS"
                },
                new Category
                {
                    CategoryId = 9,
                    CategoryName = "Meme"
                }
            );

            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Title = "Shrek",
                    Year = 2001,
                    Director = "Andrew Adamson",
                    Rating = "PG",
                    CategoryId = 9,
                    Edited = false,
                    Notes = null,
                    LentTo = null,
                },
                new Movie
                {
                    MovieId = 2,
                    Title = "Star Wars Holiday Special",
                    Year = 1978,
                    Director = "Steve Binder",
                    CategoryId = 4,
                    Rating = "PG",
                    Edited = true,
                    Notes = "Really good movie",
                    LentTo = null,
                },
                new Movie
                {
                    MovieId = 3,
                    Title = "Big Chungus",
                    Year = 2100,
                    Director = "Himself",
                    CategoryId = 1,
                    Rating = "R",
                    Edited = false,
                    Notes = "Do not watch",
                    LentTo = "Fred",
                }
            );
        }
    }
}

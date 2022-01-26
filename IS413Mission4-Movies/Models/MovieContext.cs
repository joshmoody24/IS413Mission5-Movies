using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413Mission4_Movies.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base (options)
        {

        }

        public DbSet<Movie> movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Title = "Shrek",
                    Year = 2001,
                    Director = "Andrew Adamson",
                    Rating = "PG",
                    Category = "Meme",
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
                    Category = "Idk",
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
                    Category = "Action",
                    Rating = "R",
                    Edited = false,
                    Notes = "Do not watch",
                    LentTo = "Fred",
                }
            );
        }
    }
}

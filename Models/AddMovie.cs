using System;
using Microsoft.EntityFrameworkCore;

namespace Movies.Models
{
    public class AddMovieContext : DbContext 
    {
        //initiallizing i think... I will definitely be asking questions about this one.
        public AddMovieContext(DbContextOptions<AddMovieContext> options) : base(options)
        {
            //Nothing here
        }
        public DbSet<MovieRes> Responses { get; set; } //translation: "create database with table formed in movieres and label it Responses. Get and Set that."

        // only when the model is created will this be called.
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieRes>().HasData(
                new MovieRes
                {
                    MovieID = 1, //seed 1
                    Category = "Drama",
                    Title = "Amazing Grace",
                    Year = 2007,
                    Director = "Michael Apted",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieRes
                {
                    MovieID = 2, //seed 2 etc
                    Category = "Drama",
                    Title = "The Professor and the Madman",
                    Year = 2019,
                    Director = "Farhad Safinia",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                 new MovieRes
                 {
                     MovieID = 3,
                     Category = "Action/Adventure",
                     Title = "Star Wars Episode III: Revenge of the Sith",
                     Year = 2005,
                     Director = "George Lucas",
                     Rating = "PG-13",
                     Edited = false,
                     LentTo = "",
                     Notes = "Leaves a massive gap"
                 }

                );

        }
    }
}

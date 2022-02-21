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
        public DbSet<Category> Categories { get; set; }

        // only when the model is created will this be called.
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Action/Adventure"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Drama"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Family"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Horror/Suspense"
                },
                new Category
                {
                    CategoryID = 6,
                    CategoryName = "Miscellaneous"
                },
                new Category
                {
                    CategoryID = 7,
                    CategoryName = "Television"
                },
                new Category
                {
                    CategoryID = 8,
                    CategoryName = "VHS"
                }

                );
            mb.Entity<MovieRes>().HasData(
                new MovieRes
                {
                    MovieID = 1, //seed 1
                    CategoryID = 3,
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
                    CategoryID = 3,
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
                     CategoryID = 1,
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

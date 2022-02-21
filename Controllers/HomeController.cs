using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movies.Models;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AddMovieContext SomeContext { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, AddMovieContext name)
        {
            _logger = logger;
            SomeContext = name;
        }
        //view name caller my naming convention
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet] // Identify that it is a get request 
        public IActionResult AddMovie()
        {
            ViewBag.Category = SomeContext.Categories.ToList();
            return View();
        }
        [HttpPost] //Identify that this is a post for sending the object to be saved
        public IActionResult AddMovie(MovieRes mr)
        {
            if (ModelState.IsValid)
            {
                SomeContext.Add(mr);
                SomeContext.SaveChanges();
            }
            else //if valid
            {
                ViewBag.Category = SomeContext.Categories.ToList();
                return View(mr);
            }

            return View("submited");
        }
        public IActionResult AllMovies()
        {
            var movies = SomeContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Category)
                .ToList();
            return View(movies);
        }
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            var movies = SomeContext.Responses
                .Single(x => x.MovieID == movieid);

            ViewBag.Category = SomeContext.Categories.ToList();
            return View("AddMovie", movies);
        }
        [HttpPost]
        public IActionResult Edit(MovieRes mr)
        {
            SomeContext.Update(mr);
            SomeContext.SaveChanges();

            return RedirectToAction("AllMovies");
        }
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = SomeContext.Responses
                .Single(x => x.MovieID == movieid);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(MovieRes mr)
        {
            SomeContext.Responses.Remove(mr);
            SomeContext.SaveChanges();
            return RedirectToAction("AllMovies");
        }
        public IActionResult MyPodcast()
        {
            return View();
        }

    }
}

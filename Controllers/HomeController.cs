using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        //view name caller my naming convention
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet] // Identify that it is a get request 
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost] //Identify that this is a post for sending the object to be saved
        public IActionResult AddMovie(MovieRes mr)
        {
            SomeContext.Add(mr);
            SomeContext.SaveChanges();
            

            return View("Submited"); //Redirects to the submitted page
        }
        public IActionResult MyPodcast()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

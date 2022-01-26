using IS413Mission4_Movies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IS413Mission4_Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieContext movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext mc)
        {
            _logger = logger;
            movieContext = mc;
        }

        public IActionResult Index()
        {
            return View(movieContext);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            // check to make sure all the input validation passed
            if (ModelState.IsValid)
            {
                movieContext.Add(movie);
                movieContext.SaveChanges();
                // this calls the index function (goes back to the movie collection list)
                return View("Index", movieContext);
            }
            else return View();
        }

        public IActionResult MyPodcasts()
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

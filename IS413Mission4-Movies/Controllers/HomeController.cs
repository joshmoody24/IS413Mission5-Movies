using IS413Mission5_Movies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IS413Mission5_Movies.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext mc)
        {
            movieContext = mc;
        }

        public IActionResult Index()
        {
            List<Movie> movies = movieContext.movies.Include(m => m.Category).ToList();
            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = movieContext.categories.ToList();
            ViewBag.Editing = false;
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
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = movieContext.categories.ToList();
                ViewBag.Editing = false;
                return View();
            }
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditMovie(int movieid)
        {
            //reuse the add movie form as the edit form
            ViewBag.Categories = movieContext.categories.ToList();
            ViewBag.Editing = true;
            var movie = movieContext.movies.Single(x => x.MovieId == movieid);
            return View("AddMovie", movie);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieContext.Update(movie);
                movieContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = movieContext.categories.ToList();
                ViewBag.Editing = true;
                return View("AddMovie");
            }
        }

        [HttpGet]
        public IActionResult DeleteMovie(int movieid)
        {
            Movie movie = movieContext.movies.Single(m => m.MovieId == movieid);
            return View(movie);
        }

        [HttpPost]
        public IActionResult DeleteMovie(Movie movie)
        {
            movieContext.movies.Remove(movie);
            movieContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

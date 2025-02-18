using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_BoudJacob.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_BoudJacob.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext _context;

        public HomeController(MoviesContext temp) //Constructor
        {
            _context = temp;
        }

        //Routes
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Joel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {

            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

            return View("Movies", new Movie());
        }

        [HttpPost]
        public IActionResult Movies(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); //Add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

                return View(response);
            }

        }

        [HttpGet]
        public IActionResult MovieList()
        {
            //Linq
            var movies = _context.Movies.Include(x => x.Category).OrderBy(x => x.Title).ToList();

            return View(movies);
        }

        //Edits

        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies.Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

            return View("Movies", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        //Deletes

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies.Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie deletedInfo)
        {
            _context.Movies.Remove(deletedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_BoudJacob.Models;

namespace Mission06_BoudJacob.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext _context;

        public HomeController(MoviesContext temp) //Constructor
        {
            _context = temp;
        }

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
            return View();
        }

        [HttpPost]
        public IActionResult Movies(Movie response)
        {
            _context.Movies.Add(response); //Add record to the database
            _context.SaveChanges();

            return View("Confirmation", response);
        }

    }
}

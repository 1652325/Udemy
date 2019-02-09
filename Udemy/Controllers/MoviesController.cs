using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy.Models;
using Udemy.ViewModel;

namespace Udemy.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            MoviesVm movies = new MoviesVm()
            {
                lstMovies =
                {
                    new Movie(){ Id = 1, Name = "First Movie"},
                    new Movie(){ Id = 2, Name = "Second Movie2"}
                }
            };
            return View(movies);
        }
    }
}
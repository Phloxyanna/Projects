using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //3 ways to pass data to Views

            //1) passing model to view.
            //movie object is assigned to ViewResult (View) via the ViewDataDictionary, key/value pairs or Model property to work with the object. 
            var viewResult = new ViewResult();
            //viewResult.ViewData.Model //TODO: fuzzy
            //return View(viewModel);
            return View(viewModel);

            //2) viewdatadictionary, Movie is a magic string also found in Random.cshtml
            //ViewData["Movie"] = movie;
            //return View();

            //3) ViewBag
            //ViewBag.Movie = movie;
            //return View();
        }

        //attribute route, also allows definition of constraints
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]

        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" +month);
        }

        //http://localhost:50152/movies/edit/1
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //movies
        //input parameters should be nullable, so...
        //int with ? means it is nullable, int is a value type.
        //string is a reference type and is already nullable so no change.
        //http://localhost:50152/movies/Index/?pageIndex=3&sortby=%27ReleaseDate%27
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}
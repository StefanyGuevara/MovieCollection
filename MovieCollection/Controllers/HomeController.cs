using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private MoviesAppContext daContext { get; set; }
        //CONTRUCTOR
        public HomeController( MoviesAppContext someName)
        {
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = daContext.Categories.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(ApplicationInfo ar)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(ar);
                daContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else //if invalid
            {
                ViewBag.Categories = daContext.Categories.ToList();
                return View();
            }
        }
        public IActionResult CrudMovies()
        {

            var applications = daContext.responses
                .Include(x=>x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit (int applicationid)
        {
            ViewBag.Categories = daContext.Categories.ToList();
            var application = daContext.responses.Single(x => x.ApplicationId == applicationid);
            return View("MovieForm", application);
        }

        [HttpPost]
        public IActionResult Edit (ApplicationInfo blah) 
        {
            daContext.Update(blah);
            daContext.SaveChanges();

            return RedirectToAction("CrudMovies");
        }

        [HttpGet]
        public IActionResult Delete (int applicationid)
        {
            var application = daContext.responses.Single(x => x.ApplicationId == applicationid);

            return View(application);
        }
        [HttpPost]
        public IActionResult Delete (ApplicationInfo ar)
        {
            daContext.responses.Remove(ar);
            daContext.SaveChanges();
            return RedirectToAction("CrudMovies");
        }
    }
}

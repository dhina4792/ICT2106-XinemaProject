using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Scrapper;
using XinemaProject.ViewModels;
using System.Data.Entity;
using XinemaProject.DAL;
using XinemaProject.Models;

namespace XinemaProject.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            //return View(db.Movies.ToList());
            return View();
        }


    }
}

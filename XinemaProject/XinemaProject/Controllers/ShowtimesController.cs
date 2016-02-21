using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XinemaProject.Models;

namespace XinemaProject.Controllers
{
    public class ShowtimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Showtimes
        public ActionResult Index()
        {
            
            return View();
        }

      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

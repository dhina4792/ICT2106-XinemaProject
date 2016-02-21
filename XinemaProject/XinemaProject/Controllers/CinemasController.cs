using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructure.Scrapper;
using XinemaProject.ViewModels;

namespace XinemaProject.Controllers
{
    public class CinemasController : Controller
    {

        Scrapper scrapper = new Scrapper();
        // GET: Cinemas
        public ActionResult Index()
        {
            scrapper.scrapCinemaName("https://www.google.com/movies?near=singapore&rl=1&stok=ABAPP2tdNR_5cLRa-6emW2UtecEL44SX2A%3A1456036737594");
            CinemasVM vm = new CinemasVM();
            vm.cinemasName = scrapper.getCinemaNames();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(CinemasVM vm)
        {
            return View(vm);
        }
    }
}